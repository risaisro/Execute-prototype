using UnityEngine;
using System.Collections;
using Prime31;


public class Player_abilities : MonoBehaviour
{
    // movement config
    public float gravity = -25f;
    public float runSpeed = 8f;
    public float groundDamping = 20f; // how fast do we change direction? higher means faster
    public float inAirDamping = 5f;
    public float jumpHeight = 3f;
    public float jumps = 2;

    public float attack_duration = .5f;
    public float attack_delay_time = .2f;


    public GameObject Slash;
    public GameObject Down_Slash;
    public GameObject Up_Slash;

    [HideInInspector]
    private float normalizedHorizontalSpeed = 0;

    private bool can_attack = true; 

    private CharacterController2D _controller;
    private Animator _animator;
    private RaycastHit2D _lastControllerColliderHit;
    private Vector3 _velocity;
    private Transform _fire_point;
    private Transform _down_slash_point;
    private Transform _up_slash_point;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController2D>();

        _fire_point = transform.FindChild("fire_point");
        _down_slash_point = transform.FindChild("down_slash_point");
        _up_slash_point = transform.FindChild("up_slash_point");

        // listen to some events for illustration purposes
        _controller.onControllerCollidedEvent += onControllerCollider;
        _controller.onTriggerEnterEvent += onTriggerEnterEvent;
        _controller.onTriggerExitEvent += onTriggerExitEvent;
    }


    #region Event Listeners

    void onControllerCollider(RaycastHit2D hit)
    {
        // bail out on plain old ground hits cause they arent very interesting
        if (hit.normal.y == 1f)
            return;

        // logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
        //Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
    }


    void onTriggerEnterEvent(Collider2D col)
    {
        Debug.Log("onTriggerEnterEvent: " + col.gameObject.name);
    }


    void onTriggerExitEvent(Collider2D col)
    {

    }

    #endregion


    // the Update loop contains a very simple example of moving the character around and controlling the animation
    void Update()
    {
        move();
        attack();
    }

    void move()
    {
        if (_controller.isGrounded)
            _velocity.y = 0;

        if (Input.GetKey(KeyCode.D))
        {
            normalizedHorizontalSpeed = 1;
            if (transform.localScale.x < 0f)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            if (_controller.isGrounded)
                _animator.Play(Animator.StringToHash("Run"));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            normalizedHorizontalSpeed = -1;
            if (transform.localScale.x > 0f)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            if (_controller.isGrounded)
                _animator.Play(Animator.StringToHash("Run"));
        }
        else
        {
            normalizedHorizontalSpeed = 0;

            if (_controller.isGrounded)
                _animator.Play(Animator.StringToHash("Idle"));
        }


        // we can only jump whilst grounded
        if (_controller.isGrounded == true)
        {
            jumps = 2;
        }

        if (jumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            _velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
            _animator.Play(Animator.StringToHash("Jump"));
            jumps--;
        }


        // apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
        var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
        _velocity.x = Mathf.Lerp(_velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor);

        // apply gravity before moving
        _velocity.y += gravity * Time.deltaTime;

        // if we're not jumping and holding down bump up our movement amount and turn off one way platform detection for a frame.
        // this lets us jump down through one way platforms
        if (_controller.isGrounded && Input.GetKey(KeyCode.S))
        {
            if(_velocity.y < 0) _velocity.y *= 3f; //
            _controller.ignoreOneWayPlatformsThisFrame = true;
        }

        _controller.move(_velocity * Time.deltaTime);

        // grab our current _velocity to use as a base for all calculations
        _velocity = _controller.velocity;
    }

    void attack()
    {
        if (can_attack == true &&  Input.GetMouseButton(0) == true)
        {
            GameObject attack;
            Transform attack_point;
            GameObject attack_obj;

            if (Input.GetKey(KeyCode.S))
            {
                attack_point = _down_slash_point;
                attack_obj = Down_Slash;
            }else if(Input.GetKey(KeyCode.W)){
                attack_point = _up_slash_point;
                attack_obj = Up_Slash;
            }
            else
            {
                attack_point = _fire_point;
                attack_obj = Slash;
            }

            attack = (GameObject)Instantiate(attack_obj, attack_point.position, attack_point.rotation);
            attack.GetComponent<SlashScript>().setLife(attack_duration);
            print("before init");
            attack.GetComponent<SlashScript>().Initialize(attack_point);

            if (gameObject.transform.localScale.x < 0)
            {
                attack.transform.localScale = new Vector2(attack.transform.localScale.x * -1, attack.transform.localScale.y);
            }
            can_attack = false;

            StartCoroutine(attack_delay());
        }
    }

    IEnumerator attack_delay()
    {
        yield return new WaitForSeconds(attack_delay_time);
        can_attack = true;
    }
}