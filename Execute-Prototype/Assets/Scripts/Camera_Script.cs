using UnityEngine;
using System.Collections;

public class Camera_Script : MonoBehaviour {
    private Vector2 velocity;
	// Use this for initialization
    public float cameraDelay = .5f;
    private GameObject Player;
    private float xvelocity = 0f;
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float newPosX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, cameraDelay);
        float newPosy = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, cameraDelay);
        transform.position = new Vector3(newPosX, newPosy, transform.position.z);
    }
}
