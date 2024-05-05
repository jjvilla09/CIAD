using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemPickupController : MonoBehaviour
{
    [SerializeField] Creature jay;
    [SerializeField] UIController uiController;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Debug.Log("Player has picked up a gem!");
            jay.pickupGem();
            jay.setHasGem(true);
            uiController.setGemAlpha(1f);
            Destroy(this.gameObject);
        }
    }
}
