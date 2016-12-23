using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour
{
    // public Transform target;
    public float speed = 10f;
    public Vector3 TargetPosition; 
    public bool move = false;
    float posx;
    float posy;
    GameObject Pawn1;

    // Use this for initialization
    void Start()
    {
       // TargetPosition = new Vector3(-2, 1.5f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);
        }
    }

    public void MoveObject(float x, float y)
    {
        move = true;
        TargetPosition = new Vector3(x, 1.5f, y);
    }

    public Vector3 getPosition(int i)
    {
        return GameObject.Find("Pawn" + i).transform.position;
    }   
}