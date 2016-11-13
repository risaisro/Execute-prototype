using UnityEngine;
using System.Collections;

public class Bullet2_spawner : MonoBehaviour {
    public GameObject Bullet;

    private Transform fire_point;
    private GameObject Player;
    private int Burst = 3;

    public float AttackLag = 3f;
    public float Between_shots = .1f;
    public float Bullet_life = 3f;

    public float Bullet_speed_x = 5f;

    private bool isAttacking = false;
    void Start () {
        fire_point = transform.FindChild("Soldier_firepoint");
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
        Vector2 attack_position = fire_point.position;
        Quaternion attack_rotation = fire_point.rotation;
        for (int Spawn = 0; Spawn < 10; Spawn++)
        {
            float offset_y = .5f * Spawn;
            Vector2 fire_position = new Vector2(attack_position.x, attack_position.y + offset_y);
            GameObject bullet;
            bullet = (GameObject)Instantiate(Bullet, fire_position, attack_rotation);
            bullet.GetComponent<Bullet2_pattern>().initialize(Bullet_speed_x);
            //bullet.GetComponent<Bullet2_pattern>().initialize(true);

            //bullet.GetComponent<Bullet2_pattern>().initialize(false);

            yield return new WaitForSeconds(Between_shots * Spawn/2);
        }

        yield return new WaitForSeconds(AttackLag);
        isAttacking = false;
    }
}
