using UnityEngine;
using System.Collections;
using System.IO.Ports;


public class ControlScript : MonoBehaviour {
    Player[] playerlist;
    SerialPort stream = new SerialPort("\\\\.\\COM10", 9600);


    // Use this for initialization
    void Start () {
        playerlist = new Player[2];
        stream.Open();
        stream.ReadTimeout = 1;
        
        for(int i=0; i<playerlist.Length; i++)
        {
            GameObject go = GameObject.Find("Player" + (i+1));
               if(go != null)
            {
                playerlist[i] = go.GetComponent<Player>();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (stream.IsOpen)
        {
            try
            {
                string dir = stream.ReadLine();
                //   print(dir);
                string[] values = dir.Split('=');

                if (values[1].Equals(" 1"))
                    playerlist[0].MoveObject(1);
                else if (values[1].Equals(" 2"))
                    playerlist[0].MoveObject(2);
                else if (values[1].Equals(" 3"))
                    playerlist[0].MoveObject(3);
                else if (values[1].Equals(" 4"))
                    playerlist[0].MoveObject(4);
                else if (values[1].Equals(" 5"))
                    playerlist[1].MoveObject(1);

                else if (values[1].Equals(" 6"))
                    playerlist[1].MoveObject(2);

                else if (values[1].Equals(" 7"))
                    playerlist[1].MoveObject(3);

                else if (values[1].Equals(" 8"))
                    playerlist[1].MoveObject(4);
            }
            catch (System.Exception) { }
        }

    }
}
