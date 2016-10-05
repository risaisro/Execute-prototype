using UnityEngine;
using System.Collections;

public class SoldierAI : MonoBehaviour {
    private bool isAttacking = false;
    private int Burst = 3;
    public float AttackLag = 3f;
    public float Between_shots = .3f;
    public float Bullet_life = 3f;
    private GameObject Player;
    private int Facing = 1;

    public GameObject Bullet;
    Transform fire_point;
	// Use this for initialization
	void Start () {
        fire_point = transform.FindChild("Soldier_firepoint");
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {


        if (isAttacking == false)
        {
            isAttacking = true;
            //print("isAttacking");
            StartCoroutine(Attack());
        }
	}

    IEnumerator Attack()
    {
        GameObject bullet;
        bullet = (GameObject)Instantiate(Bullet, fire_point.position, fire_point.rotation);
        bullet.GetComponent<Bullet_script>().setLife(Bullet_life);

        //print("first");
        yield return new WaitForSeconds(Between_shots);

        bullet = (GameObject)Instantiate(Bullet, fire_point.position, fire_point.rotation);
        bullet.GetComponent<Bullet_script>().setLife(Bullet_life);
        //print("second");

        yield return new WaitForSeconds(Between_shots);
        bullet = (GameObject)Instantiate(Bullet, fire_point.position, fire_point.rotation);
        bullet.GetComponent<Bullet_script>().setLife(Bullet_life);
        //print("third");

        yield return new WaitForSeconds(AttackLag);

        isAttacking = false;
        //print("isattackingisfalse");
    }
}
