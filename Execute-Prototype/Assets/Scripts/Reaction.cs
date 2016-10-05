using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Reaction : MonoBehaviour {


    public float Time_scale = .1f;
    public float Slow_motion_time = .25f;
    
    bool slowmo = false;
    // Use this for initialization
    Transform player_pos;
    void Start () {
        player_pos = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player_pos.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            if (slowmo == false)
            {
               StartCoroutine( SlowTime());
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
