using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTriggerController : MonoBehaviour
{
    
    [SerializeField] Creature jay;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            jay.SubtractLife();
        }
    }
}
