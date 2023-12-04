using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject enoughHealthImg;
    public Animator enoughHealthAnimator;
    public UIAnimations uiAnimations;
    private int maxHealth = 100;
     int savedHealth;
    public int damage = 10;
    public int currentHealth;
    public Slider HealthSlider;
    public Text powrUpBtnText;
    public Text barText;
    bool isPressed = false;
    //Set Image (bar) fill Amount
    public void SetBarFillAmount(int amount)
    {
        HealthSlider.value = amount;
    }
    void Start()
    {

        savedHealth = PlayerPrefs.GetInt("Health");
        Debug.Log(savedHealth + "totalhealth");
        currentHealth = maxHealth;
        powrUpBtnText.text = Mathf.Round(savedHealth).ToString();
        barText.text = currentHealth.ToString();
        enoughHealthImg.SetActive(false);

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
        if (currentHealth > 0 && currentHealth < maxHealth && savedHealth >= 0)
        {
            float currentHealth_float = (float)currentHealth;
            currentHealth_float +=1 * Time.deltaTime * 5f;
            currentHealth = (int)currentHealth_float;
            barText.text = currentHealth.ToString();
            float savedHealth_float = (float)savedHealth;
            savedHealth_float-= 1 * Time.deltaTime * 5f;
            savedHealth = (int)savedHealth_float;
            powrUpBtnText.text = savedHealth.ToString();
            SetBarFillAmount(currentHealth);
            PlayerPrefs.SetFloat("Health", savedHealth);
            PlayerPrefs.Save();
            
        }
        if (savedHealth <= 0)
        {
            enoughHealthImg.SetActive(true);
            enoughHealthAnimator.SetTrigger("EnoughtHealthMsg");
            
        }



    }
    public void PlayerDamage()
    {
        if (currentHealth >= 0)
        {
            currentHealth -= damage;
            SetBarFillAmount(currentHealth);
           
            barText.text = Mathf.Clamp(currentHealth, 0, Mathf.Infinity).ToString();

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
