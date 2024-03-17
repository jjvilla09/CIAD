using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemPickupController : MonoBehaviour
{
    [SerializeField] private Image gem;

    [SerializeField] Creature jay;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Debug.Log("Player has picked up a gem!");
            jay.setHasGemTrue();
            gem.color = new Color(gem.color.r, gem.color.g, gem.color.b, 1f);
            Destroy(this.gameObject);
        }
    }
}
