using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Reaction : MonoBehaviour {

    private bool Slowmo_held = false;
    public float Slowmo_max = 5f;
    public float Decrease_per_second = 1f;
    public float Slowmo_curr;
    public float increment = .25f;

    public float Time_scale = .1f;
    public float Slow_motion_time = .25f;
    
    bool slowmo = false;
    // Use this for initialization
    Transform player_pos;
    void Start () {
        Slowmo_curr = Slowmo_max;
        player_pos = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player_pos.position;
        if (Input.GetMouseButton(1))
        {
            Slowmo_held = true;
            Slowmo_curr += -Decrease_per_second * Time.deltaTime;
            if (Slowmo_curr < 0)
            {
                Slowmo_curr = 0;
                Slowmo_held = false;
                print("Slowmo is empty");
            }
        }
        else Slowmo_held = false;
        if(!Slowmo_held && Slowmo_curr < Slowmo_max)
        {
            Slowmo_curr += Decrease_per_second * .5f * Time.deltaTime;
            if (Slowmo_curr > Slowmo_max) Slowmo_curr = Slowmo_max;
        }
    }

    public void increment_bar()
    {
        if(Slowmo_curr < Slowmo_max)
        {
            Slowmo_curr += increment;
            if (Slowmo_curr > Slowmo_max) Slowmo_curr = Slowmo_max;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Slowmo_held)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {

                if (slowmo == false)
                {
                    StartCoroutine(SlowTime());
                }
            }
        }
    }

    IEnumerator SlowTime()
    {
        
        Time.timeScale = Time_scale;
        slowmo = true;

        yield return new WaitForSeconds(Slow_motion_time * Time.timeScale);
        Time.timeScale = 1f;
        slowmo = false;

    }
}
