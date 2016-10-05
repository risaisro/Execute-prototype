using UnityEngine;
using System.Collections;

public class SlashScript : MonoBehaviour {
    public float lifespan = .5f;
    int t = 0;

    private Transform follow_point;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }
    void Update()
    {
        gameObject.transform.position = follow_point.position;
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
            // print("Hit bullet");
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


    // Update is called once per frame
    
    public void setLife(float life)
    {
        lifespan = life;
    }
    public void Initialize(Transform fire_point)
    {
        print("something");
        follow_point = fire_point;
    }
}

