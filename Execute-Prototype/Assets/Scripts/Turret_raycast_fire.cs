using UnityEngine;
using System.Collections;

public class Turret_raycast_fire : MonoBehaviour {
    public GameObject bullet;
    public LayerMask Player_layer;
    public float distance = 20;
    public float attack_lag = 1f;

    public Vector2 direction = Vector2.down;
    private Quaternion bullet_rotation = Quaternion.Euler(0,0,270);


    private bool attacking = false;


	void Start () {
        if (direction == Vector2.left) bullet_rotation = Quaternion.Euler(0, 0, 180);
        if (direction == Vector2.right) bullet_rotation = Quaternion.Euler(0, 0, 0);
        if (direction == Vector2.up) bullet_rotation = Quaternion.Euler(0,0,90);
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance ,Player_layer);
        Vector2 Position2D = new Vector2(transform.position.x, transform.position.y);

        //Debug.DrawRay(transform.position, Vector2.right);


        Vector2 debugVector = new Vector2(transform.position.x + (direction.x * (distance)), transform.position.y + (direction.y * distance));

       
        Debug.DrawLine(transform.position, debugVector,Color.red);
        if (hit && !attacking)
        {
            attacking = true;
            StartCoroutine(attack());

        }
    }
    IEnumerator attack()
    {
        yield return new WaitForSeconds(.1f);
        GameObject Spawned = (GameObject)Instantiate(bullet, transform.position, bullet_rotation);
        //Spawned.GetComponent<Bullet_script>().SetDirection(direction);
        //bullet.GetComponent<Bullet_script>().SetRotation(bullet_rotation);
        yield return new WaitForSeconds(attack_lag);
        attacking = false;
    }
}
