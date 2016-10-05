using UnityEngine;
using System.Collections;

public class Scatter_shot : MonoBehaviour {
    private bool isAttacking = false;
    private int Burst = 3;
    public float AttackLag = .5f;
    private GameObject Player;
    private int Facing = 1;

    public GameObject Bullet;
    Transform fire_point;

    void Start () {
        fire_point = transform.FindChild("D.va_firepoint");
        Player = GameObject.FindGameObjectWithTag("Player");
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
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        
        //float degrees = 0;
        Instantiate(Bullet, fire_point.position, fire_point.rotation);
        for (int i = 0;i < 5; i++)
        {
            var rotationvec_plus = fire_point.rotation.eulerAngles;
            var rotationvec_minus = fire_point.rotation.eulerAngles;
            rotationvec_minus.z += -(i * 5);
            rotationvec_plus.z += (i * 5);
            Instantiate(Bullet, fire_point.position, Quaternion.Euler(rotationvec_plus));
            Instantiate(Bullet, fire_point.position, Quaternion.Euler(rotationvec_minus));
        }
        yield return new WaitForSeconds(AttackLag);
        isAttacking = false;
    }
}
