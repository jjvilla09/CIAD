using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleManController : MonoBehaviour, IInteractable
{
    [SerializeField] UIController uic;
    bool isPlayerInRange = false;
    [SerializeField] DialogueTrigger dialogueTrigger;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] DialogueSequencer dialogueSequencer;
    [SerializeField] DialogueNodeSO firstDialogueNode;

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
        uic.setHelperText("Press E to talk");
    }

    public Vector3 GetPosition() {
        return this.gameObject.transform.position;
    }

    public void Interact() {
        dialogueSequencer.StartDialogueNode(firstDialogueNode);
    }
}
