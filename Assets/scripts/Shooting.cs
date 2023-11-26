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
    public GameData gameData;
    void Start()
    {
        PlayerPrefs.SetInt("AutoFire",1);
        if (PlayerPrefs.GetInt("AutoFire")==1)
        {
            StartCoroutine(Shoot());
            

        }
        flash.SetActive(false);

    }
    public void Fire()
    {
        Instantiate(bullet, spwonPoint1.transform.position, Quaternion.identity);
        Instantiate(bullet, spwonPoint2.transform.position, Quaternion.identity);
      
    }
    public IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            flash.SetActive(true);
            Fire();
            audioSource.Play();
            yield return new WaitForSeconds(0.07f);
            flash.SetActive(false);
        }
    } public IEnumerator ButtonShoot()
    {   
            yield return new WaitForSeconds(0.1f);
            flash.SetActive(true);
            Fire();
            audioSource.Play();
            yield return new WaitForSeconds(0.07f);
            flash.SetActive(false);
    }
}
