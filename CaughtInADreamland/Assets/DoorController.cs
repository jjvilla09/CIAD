using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField] Creature jay;
    [SerializeField] UIController uiController;
    [SerializeField] FadeTransitionController fadeTransitionController;
    [SerializeField] string nextSceneName;
    string helperString = "Press E to open";
    string needGemString = "A Gem is required to open this door";
    BoxCollider2D bc;
    bool isPlayerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
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

    public bool ProximityCheck() {
        return isPlayerInRange;
    }

    public Vector3 GetPosition() {
        return this.gameObject.transform.position;
    }

    public void Interact() {
        if(isPlayerInRange && jay.getHasGem()) {
            fadeTransitionController.FadeToColor(nextSceneName);
        }
    }

    public void ShowHelperText() {
        if(jay.getHasGem()) {
            uiController.setHelperText(helperString);
        } else {
            uiController.setHelperText(needGemString);
        }
    }
}
