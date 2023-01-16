using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spwonPoint1;
    public GameObject spwonPoint2;
    public GameObject flash;
    public AudioSource audioSource;
    void Start()
    {
        StartCoroutine(Shoot());
        flash.SetActive(false);

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
            yield return new WaitForSeconds(0.4f);
            flash.SetActive(true);
            fire();
            audioSource.Play();
            yield return new WaitForSeconds(0.07f);
            flash.SetActive(false);


        }

    }
}
