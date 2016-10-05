using UnityEngine;
using System.Collections;

public class Rotate_center : MonoBehaviour {

    GameObject parent;
    Vector2 direction;
    // Use this for initialization
	void Start () {
        parent = transform.parent.gameObject;
        float dirX = -parent.transform.position.x + transform.position.x;
        float dirY = -parent.transform.position.y + transform.position.y;
        direction = new Vector2(dirX, dirY);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * Time.deltaTime * 2);
        transform.RotateAround(parent.transform.position, new Vector3(0,0,1), 80 * Time.deltaTime);
    }
    void pulse()
    {
        transform.Translate(direction * Time.deltaTime * 2);
        if (transform.position.x < -4) direction = Vector2.right;
        else if (transform.position.x > 4) direction = Vector2.left;
    }
}
