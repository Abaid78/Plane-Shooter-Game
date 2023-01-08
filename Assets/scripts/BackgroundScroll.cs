using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed=0.1f;
    public Renderer meshRanderer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frameor
    void Update()
    {
        // Vector2 offset= meshRanderer.material.mainTextureOffset;
        // offset=offset+new Vector2(0,speed*Time.deltaTime);
        // meshRanderer.material.mainTextureOffset=offset;

        meshRanderer.material.mainTextureOffset+=new Vector2(0,speed*Time.deltaTime);

        
        
    }
}
