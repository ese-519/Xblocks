using UnityEngine;
using System.Collections;
using System.IO.Ports;

//chess game
public class ControlScript : MonoBehaviour
{
    Pawn[] pawnlist;
    int g = 0;
    SerialPort stream = new SerialPort("\\\\.\\COM4", 9600);

    // Use this for initialization
    void Start()
    {
        pawnlist = new Pawn[8];
        stream.Open();
        stream.ReadTimeout = 1;

        for (int i = 0; i < pawnlist.Length; i++)
        {
            GameObject go = GameObject.Find("Pawn" + (i + 1));
            if (go != null)
            {
                pawnlist[i] = go.GetComponent<Pawn>();
            }
        }
    }

    void checkAllNMove(Vector3 newposition, int currentpawn)
    {
        for(int i = 0; i < 8; i++)
        {
            if(i != currentpawn)
            {
                if(newposition == pawnlist[i].getPosition(i + 1))
                {
                    pawnlist[i].MoveObject(-15f, -15f);
                    return;
                }
                    
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stream.IsOpen)
        {
            try {

                /*    for (int i = 0; i < 8; i++)
                  {
                      print("here");
                      print("Pawn is " + i + " " + pawnlist[i].getPosition(i + 1));
                  }*/

                    string stringis = stream.ReadLine();
               print(stringis);

                      string[] values = stringis.Split(' ');

                      float x = float.Parse(values[3]);
                      float y = float.Parse(values[4]);

                      if (values[2].Equals("B1"))
                        {
                           Vector3 newposition = new Vector3(x, 1.5f, y);
                           checkAllNMove(newposition, 0);
                           pawnlist[0].MoveObject(x,y);
                        }
                        else if (values[2].Equals("B2"))
                        {
                           Vector3 newposition = new Vector3(x, 1.5f, y);
                           checkAllNMove(newposition, 1);
                           pawnlist[1].MoveObject(x, y);
                        }
                        else if (values[2].Equals("B3"))
                        {
                           Vector3 newposition = new Vector3(x, 1.5f, y);
                           checkAllNMove(newposition, 2);
                           pawnlist[2].MoveObject(x, y);
                        }
                        else if (values[2].Equals("B4"))
                        {
                           Vector3 newposition = new Vector3(x, 1.5f, y);
                           checkAllNMove(newposition, 3);
                           pawnlist[3].MoveObject(x, y);
                        }
                        else if (values[2].Equals("A1"))
                        {
                           Vector3 newposition = new Vector3(x, 1.5f, y);
                           checkAllNMove(newposition, 4);
                           pawnlist[4].MoveObject(x, y);
                        }
                        else if (values[2].Equals("A2"))
                        {
                           Vector3 newposition = new Vector3(x, 1.5f, y);
                           checkAllNMove(newposition, 5);
                           pawnlist[5].MoveObject(x, y);
                        }
                        else if (values[2].Equals("A3"))
                        {
                           Vector3 newposition = new Vector3(x, 1.5f, y);
                           checkAllNMove(newposition, 6);
                           pawnlist[6].MoveObject(x, y);
                        }
                        else if (values[2].Equals("A4"))
                        {
                           Vector3 newposition = new Vector3(x, 1.5f, y);
                           checkAllNMove(newposition, 7);
                           pawnlist[7].MoveObject(x, y);
                        }
            }
            catch (System.Exception)
            {
               
            }
        }
    }
}