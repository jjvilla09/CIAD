using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBranchManager : MonoBehaviour
{
    public enum DialogueState { Playing, Stopped };
    public DialogueState state;
    [SerializeField] DialogueController dc;
    Dialogue currDialogue, startDialogue;
    Queue<Dialogue> dialogueGraph;
    public static DialogueBranchManager singleton;

    void Awake() {
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
        dialogueGraph = new Queue<Dialogue>();
        state = DialogueState.Stopped;
    }

    public void StartDialogue(List<Dialogue> dialogues) {
        state = DialogueState.Playing;
        dialogueGraph.Clear();
        
        int dialoguesCount = dialogues.Count;

        for(int i = 0; i < dialoguesCount; i++) {
            dialogueGraph.Enqueue(dialogues[i]);
        }

        dc.OpenDialogueBillboard();
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(dialogueGraph.Count <= 0) {
            EndDialogue();
            return;
        }

        string sentence = dialogueGraph.Dequeue().sentences[0];
        dc.RenderTextToScreen_TimedInterval(sentence);
    }

    void EndDialogue() {
        state = DialogueState.Stopped;
        dc.CloseDialogueBillboard();
        Debug.Log("Dialogue has ended.");
    }

}
