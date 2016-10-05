using UnityEngine;
using System.Collections;

public class Spark_center : MonoBehaviour {

    private Vector2 center;
    private float life;
    private float rotate_speed;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, life);
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(center, new Vector3(0, 0, 1), rotate_speed * Time.deltaTime);
    }
    public void Initialize(Transform _center, float _life, float _rotate_speed)
    {
        center = _center.position;
        life = _life;
        rotate_speed = _rotate_speed;
    }
}
