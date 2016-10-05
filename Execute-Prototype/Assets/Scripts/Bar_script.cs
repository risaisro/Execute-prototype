using UnityEngine;
using System.Collections;

public class Bar_script : MonoBehaviour {

    public float bar_size = 10f;
    public float decrease_per_second = 1f;

    private bool is_empty = true;
    private float curr_size;
	// Use this for initialization
	void Start () {
        curr_size = 0;
	}
	
	// Update is called once per frame
	void Update () {
        check_input();
        reduce();
        print(curr_size);
	}
    void check_input()
    {
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            curr_size = bar_size;
            is_empty = false;
        }
    }

    void reduce()
    {
        if (curr_size > 0)
        {
            curr_size += -decrease_per_second * Time.deltaTime;
        }
        else is_empty = true;
    }
}
