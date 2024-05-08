using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogueUIController : MonoBehaviour, DialogueNodeVisitor
{
    DialogueNodeSO nextNode;

    [Header("UI Prefabs")]
    [SerializeField] public TextMeshProUGUI dialogueText;
    [SerializeField] Canvas dialogueCanvas;
    [SerializeField] UIDialogueChoiceController ChoiceButtonPrefab;
    [SerializeField] GameObject ChoiceButtonContainer;
    [SerializeField] TextMeshProUGUI helperText;
    [SerializeField] TextMeshProUGUI characterNameText;

    [Header("Dialogue Channels")]
    [SerializeField] DialogueEventSO ui_channel;
    [SerializeField] DialogueEventSO sequencer_channel;
    [SerializeField] VoidDialogueEventSO void_dialogue_channel; // used to diable player movement when in dialogue
    [SerializeField] TextRenderer textRenderer;

    private void OnEnable() {
        ui_channel.onDialogueStart += OnDialogueNodeStart;
        ui_channel.onDialogueEnd += OnDialogueNodeEnd;
    }

    private void OnDisable() {
        ui_channel.onDialogueStart -= OnDialogueNodeStart;
        ui_channel.onDialogueEnd -= OnDialogueNodeEnd;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(textRenderer.textRendererState == TextRenderer.TextRendererState.Rendering) {
                textRenderer.DialogueSkipHandler();
            } else {
                sequencer_channel.onDialogueStart.Invoke(nextNode);
            }
        }
    }
    
    public void OnDialogueNodeStart(DialogueNodeSO node) {
        OpenDialogueBillboard();                                                            // Open the dialogue text box
        characterNameText.text = node.narration_line.narration_character.character_name;    // Set character's name in text box
        textRenderer.InitializeDialogueConfig(node, dialogueText, false);                   // Proceeds to the next dialogue
        node.Accept(this);                                                                  // Visits the node, and determines node type (basic or choice node)
    }                                                                                       // to excecute the correct functionality

    public void OnDialogueNodeEnd(DialogueNodeSO node) {
        foreach(Transform child in ChoiceButtonContainer.transform) {
            Destroy(child.gameObject);
        }
        CloseDialogueBillboard();
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
        }
    }

    public void OpenDialogueBillboard() {
        dialogueText.text = "";
        dialogueCanvas.enabled = true;
        void_dialogue_channel.RaiseVoidDialogueStartEvent();
    }

    public void CloseDialogueBillboard() {
        dialogueText.text = "";
        dialogueCanvas.enabled = false;
        void_dialogue_channel.RaiseVoidDialogueEndEvent();
    }
}
