using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spwonPoint1;
    public GameObject spwonPoint2;
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Instantiate(bullet,spwonPoint1.transform.position,Quaternion.identity);
            Instantiate(bullet,spwonPoint2.transform.position,Quaternion.identity);
        }
        
    }
}
