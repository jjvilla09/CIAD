using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] List<Dialogue> dialogueGraph;

    public void StartDialogTrigger() {
        DialogueBranchManager.singleton.StartDialogue(dialogueGraph);
    }
}
