using UnityEngine;
using System.Collections;

public class Bar_script : MonoBehaviour {

    public float bar_size = 3f;
    public float decrease_per_second = 1f;

    

    private float combo_number = 0;
    private bool is_empty = true;
    public float curr_size;
    private float frames = 0;

    public float increment = .1f;
	void Start () {
        curr_size = 0;
	}
	
	// Update is called once per frame
	void Update () {
        reduce();
        if (!is_empty) print_per_second();//print per second to be replaced with UI bar thing
	}

    //called outside of the script to increment the combo and fill the bar to decrease
    public void Combo()
    {
        curr_size = bar_size;
        is_empty = false;
        combo_number++;
    }
//called outside the function to make the bar decrease slower by incrementing it a bit
    public void increment_bar()
    {
        if (!is_empty)
        {
            curr_size += increment;
        }
    }

    void reduce()
    {
        if (curr_size > 0)
        {
            curr_size += -decrease_per_second * Time.deltaTime;
        }
        else {
            combo_number = 0;
            is_empty = true;
        }
    }
    void print_per_second()
    {
        frames += 1 * Time.deltaTime;
        if (frames > 1)
        {
            print("Combo: " + combo_number);
            print(curr_size);
            frames = 0;
        }
    }
}
