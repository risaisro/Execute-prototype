using UnityEngine;
using System.Collections;

public class Bullet_pattern_1 : MonoBehaviour {
    public GameObject Bullet;
    // Use this for initialization
    private Transform fire_point;
    private GameObject Player;
    private int Burst = 3;
    public float AttackLag = 3f;
    public float Between_shots = .3f;
    public float Bullet_life = 3f;


    private bool isAttacking = false;
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
        
        for(int Spawn = 0; Spawn < 10; Spawn++)
        {
            GameObject bullet;
            bullet = (GameObject)Instantiate(Bullet, fire_point.position, fire_point.rotation);
            bullet.GetComponent<Bullet1_pattern>().initialize(true);
            

            bullet = (GameObject)Instantiate(Bullet, fire_point.position, fire_point.rotation);
            bullet.GetComponent<Bullet1_pattern>().initialize(false);
            
            yield return new WaitForSeconds(Between_shots);
        }

        yield return new WaitForSeconds(AttackLag);
        isAttacking = false;
    }
}
