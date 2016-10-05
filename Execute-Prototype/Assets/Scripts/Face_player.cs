using UnityEngine;
using System.Collections;

public class Face_player : MonoBehaviour {

    private GameObject Player;
    // Use this for initialization

    private Vector2 left;
    private Vector2 right;

    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        //left = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
        //right = new Vector2(gameObject.transform.localScale.x * 1, gameObject.transform.localScale.y);
    }
	
	// Update is called once per frame
	void Update () {

        if (Player != null && Player.transform.position.x > transform.position.x)
        {
            //gameObject.transform.localScale = left;
            var rotationvec = transform.rotation.eulerAngles;
            rotationvec.y = 0;
            transform.rotation = Quaternion.Euler(rotationvec);
        }
        else {
            //gameObject.transform.localScale = right;
            var rotationvec = transform.rotation.eulerAngles;
            rotationvec.y = 180;
            transform.rotation = Quaternion.Euler(rotationvec);
        }
    }
}
