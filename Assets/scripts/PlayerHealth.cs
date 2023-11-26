using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject wornImg;
    float maxHealth = 100f;
    public float totalHealthValue;
    public float damage = 10;
    public float currentHealth;
    float barFillAmount = 1f;
    public Text powrUpBtnText;
    public Text barText;
    bool isPressed = false;
    public RectTransform rectTransform;
    public Image bar;
    //Set Image (bar) fill Amount
    public void SetBarFillAmount(float amount)
    {
        bar.fillAmount = amount;
    }
    void Start()
    {
       
        totalHealthValue = PlayerPrefs.GetFloat("Health");
        Debug.Log(totalHealthValue + "totalhealth");
        currentHealth = maxHealth;
        powrUpBtnText.text = Mathf.Round(totalHealthValue).ToString();
        barText.text = currentHealth.ToString();
        wornImg.SetActive(false);
    }
    void Update()
    {
        if (isPressed)
        {
            PowerUP();
        }
    }
    public void PowerUP()
    {
        if (currentHealth > 0 && currentHealth < maxHealth &&  totalHealthValue>= 0)
        {
            currentHealth = currentHealth + 1 * Time.deltaTime * 5f;
            barText.text = Mathf.Round(currentHealth).ToString();
            totalHealthValue = totalHealthValue - 1 * Time.deltaTime * 5f;
            powrUpBtnText.text = Mathf.Round(totalHealthValue).ToString();
            barFillAmount = currentHealth / maxHealth;
            SetBarFillAmount(barFillAmount);
            PlayerPrefs.SetFloat("Health", totalHealthValue);
            PlayerPrefs.Save();

        }
        if (totalHealthValue <= 0)
        {
            wornImg.SetActive(true);
            StartCoroutine(RemoveWoringImg());

        }



    }
    IEnumerator RemoveWoringImg()
    {
        yield return new WaitForSeconds(6);
        wornImg.SetActive(false);
    }
    public void PlayerDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            barFillAmount = currentHealth / maxHealth; // Calculate the fill amount
            SetBarFillAmount(barFillAmount);
            barText.text = currentHealth.ToString();

        }
    }
    public void ButtonDown()
    {
        isPressed = true;
    }
    public void ButtonUp()
    {
        isPressed = false;
    }
}
