using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Transform bar;
    // Change the scale of the bar
    public void SetBarSize(float size)
    {
        bar.localScale = new Vector2(size, 1f);
    }
}
