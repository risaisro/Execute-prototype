using UnityEngine;
using System.Collections;

public class Bullet3_sub : MonoBehaviour {
    private Vector3 offset;
    private bool do_inward = true;
	// Use this for initialization
	void Start () {
        offset = transform.localPosition; 
	}
	
	// Update is called once per frame
	void Update () {
        if (do_inward == true)
            StartCoroutine(Inward());
        if (do_inward != true)
        StartCoroutine(Outward());
        //if (do_inward = false)
	}

    IEnumerator Inward()
    {
        transform.position = Vector2.Lerp(transform.position, transform.parent.position, 1f * Time.deltaTime);
        Vector2 localPos = new Vector2(transform.localPosition.x, transform.localPosition.y);
        
            yield return new WaitForSeconds(2f);
            do_inward = false;
        
    }
    IEnumerator Outward()
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition, offset, 1f * Time.deltaTime);
        if (offset == (transform.localPosition))
        {
            yield return new WaitForSeconds(2f);
            do_inward = true;
        }
    }
}
