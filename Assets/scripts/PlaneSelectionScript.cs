using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSelectionScript : MonoBehaviour
{
    public GameObject[] planePrefabs;
    public int selectedPlane;
    private void Start()
    {
        selectedPlane = PlayerPrefs.GetInt("SelectedPlane",-1);
        if (selectedPlane >= 0)
        {
            Instantiate(planePrefabs[selectedPlane], transform.position, transform.rotation);

        }
        else
        {
            Debug.Log("Please Select a Plane");
        }
    }
}
