using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


   public void MoveObject(int direction)
    {
        //  print("here");
        //print(direction);
        if (direction == 1)
        {
            transform.Translate(100f * Time.deltaTime, 0f, 0f);
        }
        else if (direction == 2)
        {
            transform.Translate(0f, 0f, 100f * Time.deltaTime);
        }
        else if (direction == 3)
        {
            transform.Translate(0f, 0f, -100f * Time.deltaTime);
        }

        else if (direction == 4)
        {
            transform.Translate(-100f * Time.deltaTime, 0f, 0f);
        }
        else
        {
            // print("In else " + direction);
        }
    }
}
