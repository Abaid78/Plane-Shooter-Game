using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float moveSpeed=2f;
    public 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up*moveSpeed*Time.deltaTime);
    }
}
