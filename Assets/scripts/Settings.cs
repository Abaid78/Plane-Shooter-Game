using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle autoFireToggleBtn;

    // Start is called before the first frame update
    void Start()
    {
        InitializeAutoFireToggle();
    }

    #region AutoFire Settings

    void InitializeAutoFireToggle()
    {
        bool autoFireState = LoadAutoFireToggleState();
        autoFireToggleBtn.isOn = autoFireState;
    }

    public void OnAutoFireToggleValueChanged()
    {
        bool autoFireState = autoFireToggleBtn.isOn;
        SaveAutoFireToggleState(autoFireState);
    }

    void SaveAutoFireToggleState(bool state)
    {
        SaveSystem.SaveAutoFire(state);
    }

    bool LoadAutoFireToggleState()
    {
        AutoFireData loadAutoFireData = SaveSystem.LoadAutoFire();
        return loadAutoFireData.autoFire;
    }

    #endregion
}
