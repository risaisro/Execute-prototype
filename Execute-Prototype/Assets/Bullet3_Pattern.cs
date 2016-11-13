using UnityEngine;
using System.Collections;

public class Bullet3_Pattern : MonoBehaviour {
    public bool Parent = true;
    private bool spawned = false;

    public float speed = 5f;
    public float spread_wait = 2f;

    public GameObject Bullet3_sub;
    GameObject child_bullet;

    // Use this for initialization
	void Start () {
        for (int i = 1; i < 20; i++)
        {
            Vector2 unitcircle = Random.insideUnitCircle;
            Vector2 position_offset = new Vector2(transform.position.x + unitcircle.x, transform.position.y + unitcircle.y);
            child_bullet = (GameObject)Instantiate(Bullet3_sub, position_offset, transform.rotation);
            child_bullet.transform.SetParent(gameObject.transform);
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * 1f * Time.deltaTime);
        //transform.Rotate(0,0,1);
	}

    IEnumerator Spreadout()
    {
        print("got here");
        
        //yield return new WaitForSeconds(spread_wait * Time.deltaTime);
        //transform.position = Vector2.Lerp(transform.position, initial_position, spread_wait);
        yield return new WaitForSeconds(spread_wait);
    }

    public void setChild()
    {
        Parent = false;
    }
}
