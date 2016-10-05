using UnityEngine;
using System.Collections;

public class Energy_bullet : MonoBehaviour {
    public int speed = 20;
    public float life = 15f;

    private GameObject Player;
    public GameObject Target;
    GameObject reticle;

    [SerializeField]
    private Vector2 direction;
    [SerializeField] private GameObject mainchar;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, life);
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Homing());

    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(direction * Time.deltaTime * speed);

        transform.position = Vector2.MoveTowards(gameObject.transform.position, direction, Time.deltaTime * speed);
    }

    public void setDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    IEnumerator Homing()
    {
        direction = Player.transform.position;
        reticle = (GameObject)Instantiate(Target, Player.transform.position, Player.transform.rotation);
        Destroy(reticle, 1f);
        yield return new WaitForSeconds(1f);
        

        direction = Player.transform.position;
        reticle = (GameObject)Instantiate(Target, Player.transform.position, Player.transform.rotation);
        Destroy(reticle, 1f);
        yield return new WaitForSeconds(1f);

        reticle = (GameObject)Instantiate(Target, Player.transform.position, Player.transform.rotation);
        direction = Player.transform.position;
        Destroy(reticle, 1f);

        yield return new WaitForSeconds(1f);
    }
    void onDestory()
    {
        Destroy(reticle);
    }

}
