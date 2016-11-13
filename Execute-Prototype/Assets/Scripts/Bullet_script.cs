using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bullet_script : MonoBehaviour {
    public int speed = 50;
    public float life = 3f;
	int t = 0;
    public Vector2 direction = Vector2.right; //default direction is right

	void Start (){

        Destroy(gameObject, life);
       
    }

	void Update () {
        //move the bullet in the direction 
		transform.Translate (direction * Time.deltaTime * speed);
		
	}

    //used to "initialize" direction when you don't want it to go right
    public void SetDirection(Vector2 _direction){
        direction = _direction;
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }


    public void setLife(float _life)
    {
        life = _life;
    }
   
}