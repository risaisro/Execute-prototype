using UnityEngine;
using System.Collections;

public class Bullet3_spawner : MonoBehaviour
{
    public GameObject Bullet;

    private Transform fire_point;
    private GameObject Player;
    private int Burst = 3;

    public float AttackLag = 3f;
    public float Between_shots = .1f;
    public float Bullet_life = 3f;

    public float Bullet_speed_x = 5f;

    private bool isAttacking = false;
    void Start()
    {
        fire_point = transform.FindChild("Soldier_firepoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            //print("isAttacking");
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(AttackLag);
        isAttacking = false;
    }
}
