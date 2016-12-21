using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ControlScript : MonoBehaviour
{
    //toh game
    ObjectScript[] pawnlist;
    SerialPort stream = new SerialPort("\\\\.\\COM9", 9600);
    Vector3 c1low = new Vector3(12, 2, 0);
    Vector3 c1mid = new Vector3(12, 4, 0);
    Vector3 c1high = new Vector3(12, 6, 0);

    Vector3 c2low = new Vector3(0, 2, 0);
    Vector3 c2mid = new Vector3(0, 4, 0);
    Vector3 c2high = new Vector3(0, 6, 0);

    Vector3 c3low = new Vector3(-10, 2, 0);
    Vector3 c3mid = new Vector3(-10, 4, 0);
    Vector3 c3high = new Vector3(-10, 6, 0);


    // Use this for initialization
    void Start()
    {
        pawnlist = new ObjectScript[3];
        stream.Open();
        stream.ReadTimeout = 1;
        for (int i = 0; i < pawnlist.Length; i++)
        {
            GameObject go = GameObject.Find("Object" + (i + 1));
            if (go != null)
            {
                pawnlist[i] = go.GetComponent<ObjectScript>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stream.IsOpen)
        {
            try
            {
                string stringis = stream.ReadLine();
               print(stringis);
                string[] values = stringis.Split(' ');
                int cylindernumber = int.Parse(values[3]);
              /*  print("iin");
                print("First is " + pawnlist[0].getPosition(1));
                print("Second is " + pawnlist[1].getPosition(2));
                print("Thrid is " + pawnlist[2].getPosition(3));*/

                 if (values[2].Equals("A1"))
                      {
                          if (cylindernumber == 1)
                          {
                             if (!(pawnlist[1].getPosition(2) == c1low) && !(pawnlist[2].getPosition(3) == c1low))

                                     pawnlist[0].MoveObject(c1low);

                             else if (!(pawnlist[1].getPosition(2) == c1mid) && !(pawnlist[2].getPosition(3) == c1mid))
                                  pawnlist[0].MoveObject(c1mid);

                             else if (!(pawnlist[1].getPosition(2) == c1high) && !(pawnlist[2].getPosition(3) == c1high))
                                  pawnlist[0].MoveObject(c1high);

                          }
                        else  if (cylindernumber == 2)
                          {

                              if (!(pawnlist[1].getPosition(2) == c2low) && !(pawnlist[2].getPosition(3) == c2low))
                                  pawnlist[0].MoveObject(c2low);

                              else if (!(pawnlist[1].getPosition(2) == c2mid) && !(pawnlist[2].getPosition(3) == c2mid))
                                  pawnlist[0].MoveObject(c2mid);

                              else if (!(pawnlist[1].getPosition(2) == c2high) && !(pawnlist[2].getPosition(3) == c2high))
                                  pawnlist[0].MoveObject(c2high);

                          }
                         else if (cylindernumber == 3)
                          {
                            //  print("Inside here - A1 3");
                              if (!(pawnlist[1].getPosition(2) == c3low) && !(pawnlist[2].getPosition(3) == c3low))
                              {
                               //   print("Here 1");
                                  pawnlist[0].MoveObject(c3low);
                              }


                              else if (!(pawnlist[1].getPosition(2) == c3mid) && !(pawnlist[2].getPosition(3) == c3mid))
                              {
                                //  print("HEre 2");
                                  pawnlist[0].MoveObject(c3mid);
                              }

                              else if (!(pawnlist[1].getPosition(2) == c3high) && !(pawnlist[2].getPosition(3) == c3high))
                              {
                                 // print("Here 3");
                                  pawnlist[0].MoveObject(c3high);
                              }
                          }
                      }
                      //a2 
                      if (values[2].Equals("A2"))
                      {
                          if (cylindernumber == 1)
                          {
                              if (!(pawnlist[0].getPosition(1) == c1low) && !(pawnlist[2].getPosition(3) == c1low))
                                  pawnlist[1].MoveObject(c1low);

                              else if (!(pawnlist[0].getPosition(1) == c1mid) && !(pawnlist[2].getPosition(3) == c1mid))
                                  pawnlist[1].MoveObject(c1mid);

                              else if (!(pawnlist[0].getPosition(1) == c1high) && !(pawnlist[2].getPosition(3) == c1high))
                                  pawnlist[1].MoveObject(c1high);

                          }
                          else if (cylindernumber == 2)
                          {
                              if (!(pawnlist[0].getPosition(1) == c2low) && !(pawnlist[2].getPosition(3) == c2low))
                                  pawnlist[1].MoveObject(c2low);

                              else if (!(pawnlist[0].getPosition(1) == c2mid) && !(pawnlist[2].getPosition(3) == c2mid))
                                  pawnlist[1].MoveObject(c2mid);

                              else if (!(pawnlist[0].getPosition(1) == c2high) && !(pawnlist[2].getPosition(3) == c2high))
                                  pawnlist[1].MoveObject(c2high);

                          }
                          else if (cylindernumber == 3)
                          {
                              if (!(pawnlist[0].getPosition(1) == c3low) && !(pawnlist[2].getPosition(3) == c3low))
                                  pawnlist[1].MoveObject(c3low);

                              else if (!(pawnlist[0].getPosition(1) == c3mid) && !(pawnlist[2].getPosition(3) == c3mid))
                                  pawnlist[1].MoveObject(c3mid);

                              else if (!(pawnlist[0].getPosition(1) == c3high) && !(pawnlist[2].getPosition(3) == c3high))
                                  pawnlist[1].MoveObject(c3high);

                          }
                      }
                      //a3
                      if (values[2].Equals("A3"))
                      {
                          if (cylindernumber == 1)
                          {
                              if (!(pawnlist[1].getPosition(2) == c1low) && !(pawnlist[0].getPosition(1) == c1low))
                                  pawnlist[2].MoveObject(c1low);

                              else if (!(pawnlist[1].getPosition(2) == c1mid) && !(pawnlist[0].getPosition(1) == c1mid))
                                  pawnlist[2].MoveObject(c1mid);

                              else if (!(pawnlist[1].getPosition(2) == c1high) && !(pawnlist[0].getPosition(1) == c1high))
                                  pawnlist[2].MoveObject(c1high);

                          }
                          else if (cylindernumber == 2)
                          {
                              if (!(pawnlist[1].getPosition(2) == c2low) && !(pawnlist[0].getPosition(1) == c2low))
                                  pawnlist[2].MoveObject(c2low);

                              else if (!(pawnlist[1].getPosition(2) == c2mid) && !(pawnlist[0].getPosition(1) == c2mid))
                                  pawnlist[2].MoveObject(c2mid);

                              else if (!(pawnlist[1].getPosition(2) == c2high) && !(pawnlist[0].getPosition(1) == c2high))
                                  pawnlist[2].MoveObject(c2high);

                          }
                          else if (cylindernumber == 3)
                          {
                              if (!(pawnlist[1].getPosition(2) == c3low) && !(pawnlist[0].getPosition(1) == c3low))
                                  pawnlist[2].MoveObject(c3low);

                              else if (!(pawnlist[1].getPosition(2) == c3mid) && !(pawnlist[0].getPosition(1) == c3mid))
                                  pawnlist[2].MoveObject(c3mid);

                              else if (!(pawnlist[1].getPosition(2) == c3high) && !(pawnlist[0].getPosition(1) == c3high))
                                  pawnlist[2].MoveObject(c3high);

                          }
                      }
            }
            catch (System.Exception)
            {

            }
        }
    }
}