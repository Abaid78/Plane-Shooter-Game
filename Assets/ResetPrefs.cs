using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefs : MonoBehaviour
{
  
    public void ResetAllPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
