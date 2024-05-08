using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObject/VoidDialogueEventSO")]
public class VoidDialogueEventSO : ScriptableObject
{
    public UnityAction onDialogueStart;
    public UnityAction onDialogueEnd;

    public void RaiseVoidDialogueStartEvent() {
        if(onDialogueStart != null) {
            onDialogueStart.Invoke();
        } else {
            Debug.LogWarning("Attempting to raise dialogue start event with no listeners.");
        }
    }

    public void RaiseVoidDialogueEndEvent() {
        if(onDialogueEnd != null) {
            onDialogueEnd.Invoke();
        } else {
            Debug.LogWarning("Attempting to raise dialogue end event with no listeners.");
        }
    }
}
