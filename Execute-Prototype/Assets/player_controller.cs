﻿using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {

    public int runVelocity = 10;
    public int jumpVelocity = 20;
    public float airDampTime = 5f;
    public float groundDampTime = 20f;
    public float gravity = 20.0f;
    

    private bool can_attack = true;
    private Vector2 velocity;
    private Controller controller;
    private float currvelocity;

    public float attack_duration = .2f;
    public float attack_delay_time = .2f;
    public float jumps = 2;

    public GameObject Slash;
    public GameObject Down_Slash;
    public GameObject Up_Slash;

    private Transform _fire_point;
    private Transform _down_slash_point;
    private Transform _up_slash_point;

    private int direction = 0;

    private float currjumps;
    private bool isGrounded = false;
    // Use this for initialization
    void Start() {
        controller = GetComponent<Controller>();
        velocity.x = 0;
        velocity.y = 0;

        
        _fire_point = transform.FindChild("fire_point");
        _down_slash_point = transform.FindChild("down_slash_point");
        _up_slash_point = transform.FindChild("up_slash_point");
    }

    // Update is called once per frame
    void Update() {
        move();
        attack();
    }

    void move()
    {
        if (controller.collision.ceiling || controller.collision.floor)
        {
            velocity.y = 0;
            if (controller.collision.floor)
            {
                isGrounded = true;
                currjumps = jumps;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            direction = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            direction = 1;
        }
        else {

            direction = 0;
        }

        float DampTime;
        if(isGrounded)
        {
            DampTime = groundDampTime;
        }
        else
        {
            DampTime = airDampTime;
        }

        //velocity.x = Mathf.SmoothDamp(velocity.x, direction * runVelocity, ref currvelocity, Time.deltaTime * DampTime);
        velocity.x = Mathf.Lerp(velocity.x, direction * runVelocity,Time.deltaTime * DampTime);
        if (Input.GetKeyDown(KeyCode.Space) && currjumps > 0)
        {
            if (isGrounded)
            {
                isGrounded = false;
            }
            currjumps--;
            velocity.y = Mathf.Sqrt(2 * jumpVelocity * gravity);
        }

        velocity.y -= (gravity * Time.deltaTime);
        controller.move(velocity * Time.deltaTime);

    }

    void attack()
    {
        if (can_attack == true && Input.GetMouseButton(0) == true)
        {
            GameObject attack;
            Transform attack_point;
            GameObject attack_obj;

            if (Input.GetKey(KeyCode.S))
            {
                attack_point = _down_slash_point;
                attack_obj = Down_Slash;
            }
            else if (Input.GetKey(KeyCode.W))
            {
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

    public bool check_grounded()
    {
        return isGrounded;
    }
    public void add_jump()
    {
        currjumps++;
    }
}
