using UnityEngine;
using System.Collections;

public class Teleport_slash : MonoBehaviour {

    public GameObject Slash_stream;
    public float teleport_distance = 20f;
    public float Slash_cooldown = 3f;

    private bool can_slash = true;
    private Transform slash_stream_point;

	// Use this for initialization
	void Start () {
        slash_stream_point = transform.FindChild("slash_stream_point");
        
	}

    // Update is called once per frame
    void Update()
    {
        if (can_slash)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
            {
                do_Teleport_slash();
                StartCoroutine(Cooldown());
            }
        }
    }

    void do_Teleport_slash()
    {
        gameObject.GetComponent<player_controller>().add_jump();
        float direction = 1;
        if(transform.localScale.x < 0)
        {
            direction = -1;
        }
        float Xpos = transform.position.x;
        float Ypos = transform.position.y;
        Vector2 newPos = new Vector2(Xpos + (teleport_distance * direction), Ypos);
        gameObject.transform.position = newPos;
        GameObject stream = (GameObject) Instantiate(Slash_stream, slash_stream_point.position, slash_stream_point.rotation);
        if (direction == -1)
        {
            stream.transform.localScale = new Vector2(stream.transform.localScale.x * -1, stream.transform.localScale.y);
        }
        can_slash = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(Slash_cooldown);
        can_slash = true;
    }
}
