using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    Shooting shooting;
    void Start()
    {
        shooting = FindObjectOfType<Shooting>();
    }
    public void AutoShoot()
    {
        //shooting.Fire();
        StartCoroutine(shooting.ButtonShoot());
       
    }

}
