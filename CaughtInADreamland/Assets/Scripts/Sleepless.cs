using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleepless : MonoBehaviour
{
    [SerializeField] Creature player;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            player.SubtractLife();
        }
    }
}
