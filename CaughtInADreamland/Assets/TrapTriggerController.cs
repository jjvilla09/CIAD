using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTriggerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Debug.Log("Player has entered into a trap!");
            
        }
    }
}
