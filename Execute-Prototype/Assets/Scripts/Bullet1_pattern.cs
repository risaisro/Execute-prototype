using UnityEngine;
using System.Collections;

public class Bullet1_pattern : MonoBehaviour {

    public float speed_x = 5f;
    public float speed_y = 5f;
    public float peak = 2f;

    private float initial_y;
    private Vector2 Velocity;

    float Upward_bound;
    float Downward_bound;

    private Vector2 direction_x = Vector2.right;//1,0
    private Vector2 direction_y = Vector2.up;//0,1;
    float time;

    bool moving_upward = true;
    bool moving_downward;
    float average_velocity;

    float lifespan = 20f;

    void Start () {
        Destroy(gameObject, lifespan);
        initial_y = transform.position.y;
        Upward_bound = initial_y + peak;
        Downward_bound = initial_y - peak;

        //time = peak / speed_y/ 2;

    }
	
	// Update is called once per frame
	void FixedUpdate () { 

        if (moving_upward)
        {
            Vector2 target_position = new Vector2(transform.position.x, Upward_bound);
            transform.position = Vector2.SmoothDamp(transform.position, target_position, ref Velocity, .1f, speed_y);
            if (new Vector2(transform.position.x, transform.position.y) == target_position)
            {
                moving_upward = false;
                //moving_downward = true;
            }
        }
        else
        {
            Vector2 target_position = new Vector2(transform.position.x, Downward_bound);
            transform.position = Vector2.SmoothDamp(transform.position, target_position, ref Velocity, .1f, speed_y);
            if (new Vector2(transform.position.x, transform.position.y) == target_position)
            {
                moving_upward = true;
            }
        }
        transform.Translate(Vector2.right * Time.deltaTime * speed_x);

    }

    public void initialize(bool is_moving_upward)
    {
        moving_upward = is_moving_upward;
    }

    
}
