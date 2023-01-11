using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public float speed=10f;
    float minX;
    float maxX;
    float minY;
    float maxY;
    // Start is called before the first frame update
    void Start()
    {
        FindBoundries();
    }

    // Update is called once per frame
    void Update()
    {
        ///Player Movement using Input Manager
        //Horizontal Movement(Left Right)
        float deltaX=Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        float newXpos=Mathf.Clamp(transform.position.x+deltaX,minX,maxX);
        transform.position=new Vector2(newXpos,transform.position.y);
        //Vertical Movement(UP and Down)
        float deltaY=Input.GetAxis("Vertical")*Time.deltaTime*speed;
        float newYpos=Mathf.Clamp(transform.position.y+deltaY,minY,maxY);
        transform.position=new Vector2(newXpos,newYpos);
    }
    void FindBoundries(){
        Camera gameCamera=Camera.main;
        //convert position Viewport to WorldPoint
        minX=gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x+0.8f;
        maxX=gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x-0.8f;
        minY=gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y+0.7f;
        maxY=gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y-0.7f;

    }
}
