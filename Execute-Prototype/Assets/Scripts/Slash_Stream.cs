using UnityEngine;
using System.Collections;

public class Slash_Stream : MonoBehaviour {
    public float Lifespan = .3f;
    
	// Use this for initialization
	void Start () {
       
        float destroyvar = Lifespan/6;
        float addincrement = destroyvar;
	    foreach(Transform child in transform)
        {
            Destroy(child.gameObject, destroyvar);
            destroyvar += addincrement;
        }
        Destroy(gameObject, Lifespan);
	}
	
	// Update is called once per frame
	void Update () {
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet") {
            Destroy(other.gameObject);
            //print("Hit bullet");
}
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
           //print("Hit enemy");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            //print("Hit bullet");
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            //print("Hit enemy");
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    { 
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            //print("Hit bullet");
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            //print("Hit enemy");
        }
    }
}
