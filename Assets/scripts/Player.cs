using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public float speed=10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ///Player Movement using Input Manager
        //Horizontal Movement(Left Right)
        float deltaX=Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        float newXpos=transform.position.x+deltaX;
        transform.position=new Vector2(newXpos,transform.position.y);
        //Vertical Movement(UP and Down)
        float deltaY=Input.GetAxis("Vertical")*Time.deltaTime*speed;
        float newYpos=transform.position.y+deltaY;
        transform.position=new Vector2(newXpos,newYpos);
    }
}
