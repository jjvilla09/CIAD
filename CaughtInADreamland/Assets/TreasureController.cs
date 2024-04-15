using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    [SerializeField] SoulFragmentSpawner sfs;
    [SerializeField] UIController uic;
    [SerializeField] PlayerInputHandler pih;
    
    [SerializeField] Sprite openedChestSprite;
    bool isOpened = false;
    SpriteRenderer sr;
    bool isPlayerInRange = false;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        
    }

    void Update() {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isOpened) {
            openChest();
        }
    }

    bool ProximityCheck() {
        return isPlayerInRange;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            if(isOpened == false) {
                uic.setHelperText("Press E to Open Chest");
            } else {
                uic.setHelperText("Chest is already opened!");
            }
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            uic.setHelperText("");
            isPlayerInRange = false;
        }
    }

    void openChest() {
        int nSoulsFound = sfs.SpawnSoulWithForce_TimedInterval();
        isOpened = true;
        sr.sprite = openedChestSprite;
        uic.setHelperText("You found " + nSoulsFound.ToString() + " souls!") ;
        // add sound effect
    }
}
