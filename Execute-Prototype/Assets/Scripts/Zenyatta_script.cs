using UnityEngine;
using System.Collections;

public class Zenyatta_script : MonoBehaviour {


    public GameObject Attack_object;
    public float attack_delay = 2f;
    public float attack_life = 15f;
    public float attack_rotate_speed = .5f;
    // Use this for initialization

    private bool can_attack = true;

    //4 different points. North, West, East, South. they are all equally moved away from the "center"
    private Transform _fire_pointW;
    private Transform _fire_pointN;
    private Transform _fire_pointE;
    private Transform _fire_pointS;

    void Start () {
        _fire_pointW = transform.FindChild("Zen_fire_pointW");
        _fire_pointN = transform.FindChild("Zen_fire_pointN");
        _fire_pointE = transform.FindChild("Zen_fire_pointE");
        _fire_pointS = transform.FindChild("Zen_fire_pointS");
    }
	
	// Update is called once per frame
	void Update () {
        if (can_attack)
        {
            StartCoroutine(Attack());
            can_attack = false;
        }

    }

    IEnumerator Attack()
    {
        //just making the attack spawn spawn in the 4 seperate locations
        GameObject attack = (GameObject)Instantiate(Attack_object, _fire_pointW.position, _fire_pointW.rotation);
        //initialize the attack with this object's location, the set life_span, and the rotation speed
        attack.GetComponent<Spark_center>().Initialize(gameObject.transform, attack_life, attack_rotate_speed); 

        attack = (GameObject)Instantiate(Attack_object, _fire_pointN.position, _fire_pointN.rotation);
        attack.GetComponent<Spark_center>().Initialize(gameObject.transform, attack_life, attack_rotate_speed);

        attack = (GameObject)Instantiate(Attack_object, _fire_pointE.position, _fire_pointE.rotation);
        attack.GetComponent<Spark_center>().Initialize(gameObject.transform, attack_life, attack_rotate_speed);

        attack = (GameObject)Instantiate(Attack_object, _fire_pointS.position, _fire_pointS.rotation);
        attack.GetComponent<Spark_center>().Initialize(gameObject.transform, attack_life, attack_rotate_speed);

        yield return new WaitForSeconds(attack_delay);
        can_attack = true;
    }
}
