using UnityEngine;
using System.Collections;

public class Bullet2_pattern : MonoBehaviour {
    public float speed_x = 1f;
    public float lifespan = 20f;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, lifespan);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed_x * Time.deltaTime);
	}

    public void initialize(float speed)
    {
        speed_x = speed;
    }
}
