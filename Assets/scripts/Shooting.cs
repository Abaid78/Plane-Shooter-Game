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
    bool isAutoFire;
    void Start()
    {
        isAutoFire = LoadSToggleState();
        if (isAutoFire)
        {
            StartCoroutine(Shoot(0.4f));


        }
     
        flash.SetActive(false);

    }
    bool LoadSToggleState()
    {
        AutoFireData loadFireData = SaveSystem.LoadAutoFire();
        return loadFireData.autoFire;
    }
    public void Fire()
    {
        Instantiate(bullet, spwonPoint1.transform.position, Quaternion.identity);
        Instantiate(bullet, spwonPoint2.transform.position, Quaternion.identity);
      
    }
    public IEnumerator Shoot( float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            flash.SetActive(true);
            Fire();
            audioSource.Play();
            yield return new WaitForSeconds(0.07f);
            flash.SetActive(false);
        }
    } public IEnumerator Shoot1( float time)
    {
       
            yield return new WaitForSeconds(time);
            flash.SetActive(true);
            Fire();
            audioSource.Play();
            yield return new WaitForSeconds(0.07f);
            flash.SetActive(false);
        
    } 
    public void  ButtonShoot()
    {
        
        StartCoroutine(Shoot1(0.1f));
    }
}
