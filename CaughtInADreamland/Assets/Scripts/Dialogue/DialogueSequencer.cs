using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEvent : UnityEvent<DialogueNodeSO> { }

public class DialogueSequencer : MonoBehaviour
{  
    [SerializeField] DialogueUIController dialogueUIController;
    [SerializeField] DialogueNodeSO firstNode;
    [SerializeField] DialogueEventSO ui_channel;
    [SerializeField] DialogueEventSO sequencer_channel;
    DialogueNodeSO currNode;

    bool CanStartNode(DialogueNodeSO node) {
        return (currNode == null || node == null || currNode.CanBeFollowedByNode(node));
    }

    private void OnEnable() {
        sequencer_channel.onDialogueStart += StartDialogueNode;
        sequencer_channel.onDialogueEnd += EndDialogueNode;
    }

    private void OnDisable() {
        sequencer_channel.onDialogueStart -= StartDialogueNode;
        sequencer_channel.onDialogueEnd -= EndDialogueNode;
    }

    public void StartDialogueNode(DialogueNodeSO node) {
        if(CanStartNode(node)) {
            EndDialogueNode(currNode);
            currNode = node;

            if(currNode != null) {
                ui_channel.RaiseDialogueStartEvent(node);
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
            ui_channel.RaiseDialogueEndEvent(node);
        } else {
            Debug.LogWarning("Trying to stop a dialogue that isn't running.");
        }
    }
}
