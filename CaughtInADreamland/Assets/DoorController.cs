using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorController : MonoBehaviour
{
    [SerializeField] Creature jay;
    [SerializeField] UIController uiController;
    string helperString = "Press E to open";
    string needGemString = "A Gem is required to open this door";
    BoxCollider2D bc;

    bool isPlayerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getIsPlayerInRange() {
        return this.isPlayerInRange;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            isPlayerInRange = true;

            if(jay.getHasGem()) {
                uiController.setHelperText(helperString);
            } else {
                uiController.setHelperText(needGemString);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            isPlayerInRange = false;
            uiController.setHelperText("");
        }
    }
}
