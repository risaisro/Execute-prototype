using UnityEngine;
using System.Collections;

public class Pharah_Script : MonoBehaviour {

    private bool isAttacking = false;
    //private int Burst = 3;
    public float AttackLag = 2f;

    public GameObject Bullet;
    public float trigger_distance = 10;

    Transform fire_point;
    private bool triggered = false;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fire_point = transform.FindChild("Soldier_firepoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            Attack();
        } else
        {
            if (Vector2.Distance(transform.position, player.transform.position) < trigger_distance)
            {
                triggered = true;
            } 
        }
    }
    void onTriggerEnterEvent(Collider2D col)
    {
        Debug.Log("onTriggerEnterEvent: " + col.gameObject.name);
        Destroy(gameObject);
    }
    void Attack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            //print("isAttacking");
            StartCoroutine(Attacking());
        }
    }

    IEnumerator Attacking()
    {
        Instantiate(Bullet, fire_point.position, fire_point.rotation);
        //if (gameObject.transform.localScale.x < 0)
        //{
        //    attack.transform.localScale = new Vector2(attack.transform.localScale.x * -1, attack.transform.localScale.y);
        //}

        yield return new WaitForSeconds(AttackLag);

        isAttacking = false;
        //print("isattackingisfalse");
    }
}