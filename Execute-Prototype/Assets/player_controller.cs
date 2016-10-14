using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {

    public int runVelocity = 10;
    public int jumpVelocoty = 20;
    public float gravity = 3.0f;

    private Vector2 velocity;
    private Controller controller;


    // Use this for initialization
    void Start() {
        controller = GetComponent<Controller>();
        velocity.x = 0;
        velocity.y = 0;
    }

    // Update is called once per frame
    void Update() {

        if (controller.collision.ceiling || controller.collision.floor) {
            velocity.y = 0;
        }

        if (Input.GetKey(KeyCode.W))
            velocity.y = runVelocity;
        else if (Input.GetKey(KeyCode.A))
            velocity.x = -runVelocity;
        else if (Input.GetKey(KeyCode.S))
            velocity.y = -runVelocity;
        else if (Input.GetKey(KeyCode.D))
            velocity.x = runVelocity;
        else
            velocity.x = 0;

        if (Input.GetKey(KeyCode.Space) && controller.collision.floor)
            velocity.y = jumpVelocoty;

        velocity.y -= gravity;
        controller.move(velocity * Time.deltaTime);
    }
}
