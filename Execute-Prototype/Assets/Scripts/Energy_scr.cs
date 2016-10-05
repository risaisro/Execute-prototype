using UnityEngine;
using System.Collections;

public class Energy_scr : MonoBehaviour {
	public float lifespan = 50;
	public float speed = .0001f;
	GameObject obj;
	int t = 0;


	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
		if (t >= lifespan) {
			Destroy (gameObject);
		}
		t++;
	}
	void OnCollisionEnter2D(Collision2D coll){
		Destroy (gameObject);
	}
}
