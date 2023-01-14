using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
   public Image bar;
   //Set Image (bar) fill Amount
   public void SetBarFillAmount(float amount){
        bar.fillAmount=amount;
   }
}
