using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogueUIController : MonoBehaviour, DialogueNodeVisitor
{
    public DialogueEvent requestStartEvent;
    [SerializeField] DialogueController dialogueController;
    [SerializeField] DialogueSequencer dialogueSequencer;
    DialogueNodeSO nextNode;
    [SerializeField] UIDialogueChoiceController ChoiceButtonPrefab;
    [SerializeField] GameObject ChoiceButtonContainer;
    [SerializeField] TextMeshProUGUI helperText;
    [SerializeField] TextMeshProUGUI characterNameText;

    private void Awake() {
        if(requestStartEvent == null) {
            requestStartEvent = new DialogueEvent();
        }
        requestStartEvent.AddListener(dialogueSequencer.StartDialogueNode);
    }

    private void OnDestroy() {
        requestStartEvent.RemoveAllListeners();
    }

    void Update() {
        if(dialogueController.state.Equals(DialogueController.DialogueState.Running) && Input.GetKeyDown(KeyCode.Space)) {
            dialogueController.RenderTextToScreen_Skip();
        } else 
        if(!dialogueController.state.Equals(DialogueController.DialogueState.Stopped) && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log(dialogueController.state.ToString());
            requestStartEvent.Invoke(nextNode);
        }
    }
    
    public void OnDialogueNodeStart(DialogueNodeSO node) {
        //Debug.Log(node.narration_line.narration_text);
        dialogueController.OpenDialogueBillboard();
        characterNameText.text = node.narration_line.narration_character.character_name;
        dialogueController.RenderTextToScreen_TimedInterval(node.narration_line.narration_text);
        node.Accept(this);
    }

    public void OnDialogueNodeEnd(DialogueNodeSO node) {
        foreach(Transform child in ChoiceButtonContainer.transform) {
            Destroy(child.gameObject);
        }
        dialogueController.CloseDialogueBillboard();
        helperText.text = "";
        characterNameText.text = "";
    }

    public void Visit(BasicDialogueNodeSO node) {
        nextNode = node.next_node;
        helperText.text = "Press [Space] to proceed.";
    }

    public void Visit(ChoiceDialogueNodeSO node) {
        helperText.text = "Make a choice to proceed.";
        foreach(DialogueChoice choice in node.choices) {
            UIDialogueChoiceController newChoice = Instantiate(ChoiceButtonPrefab, ChoiceButtonContainer.transform);
            newChoice.Choice = choice;
            newChoice.ConnectSequencer(dialogueSequencer);
        }
    }
}
