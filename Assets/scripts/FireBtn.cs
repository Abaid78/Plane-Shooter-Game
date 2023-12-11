using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBtn : MonoBehaviour
{
    private Shooting shootingScript;
    public GameObject shootingBtn;
    bool isAutoFire;

    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(FindScriptAndInitialize());
    }

    IEnumerator FindScriptAndInitialize()
    {
        yield return null; // Wait for the next frame

        shootingScript = FindObjectOfType<Shooting>();
        if (shootingScript != null)
        {
            InitializeAutoFireState();
            UpdateShootingButtonVisibility();
        }
        else
        {
            Debug.LogWarning("Shooting script not found.");
        }
    }

    void InitializeAutoFireState()
    {
        isAutoFire = LoadAutoFireToggleState();
    }

    void UpdateShootingButtonVisibility()
    {
        shootingBtn.SetActive(!isAutoFire);
    }

    bool LoadAutoFireToggleState()
    {
        AutoFireData loadAutoFireData = SaveSystem.LoadAutoFire();
        return loadAutoFireData.autoFire;
    }

    public void BtnShooting()
    {
        shootingScript.ButtonShoot();
    }
}
