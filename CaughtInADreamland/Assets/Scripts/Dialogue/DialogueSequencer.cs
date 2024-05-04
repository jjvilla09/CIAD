using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEvent : UnityEvent<DialogueNodeSO> { }

public class DialogueSequencer : MonoBehaviour
{  
    [SerializeField] DialogueUIController dialogueUIController;
    [SerializeField] DialogueNodeSO firstNode;
    public DialogueEvent startEvent;
    public DialogueEvent endEvent;
    DialogueNodeSO currNode;

    private void Awake() {
        if(startEvent == null) {
            startEvent = new DialogueEvent();
        }
        if(endEvent == null) {
            endEvent = new DialogueEvent();
        }
        startEvent.AddListener(dialogueUIController.OnDialogueNodeStart);
        endEvent.AddListener(dialogueUIController.OnDialogueNodeEnd);
    }

    private void OnDestroy() {
        startEvent.RemoveAllListeners();
        endEvent.RemoveAllListeners();
    }

    private void Start() {
        //StartDialogueNode(firstNode);
    }

    bool CanStartNode(DialogueNodeSO node) {
        return (currNode == null || node == null || currNode.CanBeFollowedByNode(node));
    }

    public void StartDialogueNode(DialogueNodeSO node) {
        if(CanStartNode(node)) {
            EndDialogueNode(currNode);
            currNode = node;

            if(currNode != null) {
                startEvent.Invoke(node);
            } else {
                EndDialogueNode(node);
            }
        } else {
            Debug.LogWarning("Failed to start dialogue.");
        }
    }

    void EndDialogueNode(DialogueNodeSO node) {
        if(currNode == node) {
            currNode = null;
            endEvent.Invoke(node);
        } else {
            Debug.LogWarning("Trying to stop a dialogue that isn't running.");
        }
    }
}
