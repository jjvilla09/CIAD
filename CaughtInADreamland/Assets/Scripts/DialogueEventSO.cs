using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObject/DialogueEventSO")]
public class DialogueEventSO : ScriptableObject {
    public UnityAction<DialogueNodeSO> onDialogueStart;
    public UnityAction<DialogueNodeSO> onDialogueEnd;

    public void RaiseDialogueStartEvent(DialogueNodeSO node) {
        if(onDialogueStart != null) {
            onDialogueStart.Invoke(node);
        } else {
            Debug.LogWarning("Attempting to raise dialogue start event with no listeners.");
        }
    }

    public void RaiseDialogueEndEvent(DialogueNodeSO node) {
        if(onDialogueEnd != null) {
            onDialogueEnd.Invoke(node);
        } else {
            Debug.LogWarning("Attempting to raise dialogue end event with no listeners.");
        }
    }
}