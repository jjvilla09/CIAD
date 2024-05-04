using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour, IInteractable
{
    [SerializeField] SoulFragmentSpawner sfs;
    [SerializeField] UIController uic;
    [SerializeField] PlayerInputHandler pih;
    
    [SerializeField] Sprite openedChestSprite;
    bool isOpened = false;
    SpriteRenderer sr;
    bool isPlayerInRange = false;
    int HelperTextID = 0;
    float timer = 0;
    [SerializeField] float nSoulsFoundTextTime;
    int nSoulsFound = 0;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        
    }

    void Update() {
        // if(isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isOpened) {
        //     openChest();
        // }
    }

    public bool ProximityCheck() {
        return isPlayerInRange;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            isPlayerInRange = false;
        }
    }

    public void ShowHelperText() {
        switch(HelperTextID) {
            case 0:
                uic.setHelperText("Press E to Open Chest");
                break;
            case 1:
                uic.setHelperText("Chest is already opened!");
                break;
            case 2:
                if(timer < nSoulsFoundTextTime) {
                    uic.setHelperText("You found " + nSoulsFound.ToString() + " souls!");
                    timer += Time.deltaTime;
                } else {
                    HelperTextID = 1;
                    timer = 0;
                }
                break;
            default:
                uic.setHelperText("");
                break;
        }
        // if(isOpened == false) {
        //     uic.setHelperText("Press E to Open Chest");
        // } else {
        //     uic.setHelperText("Chest is already opened!");
        // }
    }

    void OpenChest() {
        isOpened = true;
        HelperTextID = 2;

        nSoulsFound = sfs.SpawnSoulWithForce_TimedInterval();
        sr.sprite = openedChestSprite;
        
        // add sound effect
    }

    public Vector3 GetPosition() {
        return this.gameObject.transform.position;
    }

    public void Interact() {
        if(!isOpened) {
            Debug.Log("Interacted with treasure object!");
            OpenChest();
        } else {
            Debug.Log("Warning: Cannot interact with treasure that has already been opened!");
        }
    }
}
