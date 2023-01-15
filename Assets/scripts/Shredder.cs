using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    //Destroy all object collide with this
    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
