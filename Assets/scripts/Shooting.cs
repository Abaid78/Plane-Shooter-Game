using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spwonPoint1;
    public GameObject spwonPoint2;
    public GameObject flash;
    void Start()
    {
        StartCoroutine(Shoot());
        flash.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {


    }
    void fire()
    {
        Instantiate(bullet, spwonPoint1.transform.position, Quaternion.identity);
        Instantiate(bullet, spwonPoint2.transform.position, Quaternion.identity);
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            flash.SetActive(true);
            fire();
            yield return new WaitForSeconds(0.07f);
            flash.SetActive(false);


        }

    }
}
