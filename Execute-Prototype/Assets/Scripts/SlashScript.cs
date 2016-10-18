using UnityEngine;
using System.Collections;

public class SlashScript : MonoBehaviour {
    public float lifespan = .5f;
    int t = 0;

    private Transform follow_point;
    GameObject combo_bar;
    GameObject slowmo;

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
            slowmo = GameObject.FindGameObjectWithTag("Slowmo");
            slowmo.GetComponent<Reaction>().increment_bar();
        }
        if (other.gameObject.tag == "Enemy") { 
            combo_bar = GameObject.FindGameObjectWithTag("Combo Bar");
            combo_bar.GetComponent<Bar_script>().Combo();

            Destroy(other.gameObject);
            //print("Hit enemy");
        }
    }
    /*
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
    }*/
    
    
    public void setLife(float life)
    {
        lifespan = life;
    }
    public void Initialize(Transform fire_point)
    {
        follow_point = fire_point;
    }
}

