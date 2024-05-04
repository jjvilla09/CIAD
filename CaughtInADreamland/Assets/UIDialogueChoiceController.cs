using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDialogueChoiceController : MonoBehaviour
{
    public DialogueEvent requestStartEvent;
    [SerializeField] private TextMeshProUGUI m_Choice;

    DialogueSequencer dialogueSequencer;

    private DialogueNodeSO m_ChoiceNextNode;

    private Button ChoiceButton;

    public DialogueChoice Choice
    {
        set
        {
            m_Choice.text = value.choice_preview;
            m_ChoiceNextNode = value.choice_node;
        }
    }

    private void Awake() {
        if(requestStartEvent == null) {
            requestStartEvent = new DialogueEvent();
        }
        ChoiceButton = GetComponent<Button>();
    }

    private void OnDestroy() {
        requestStartEvent.RemoveAllListeners();
    }

    private void OnClick()
    {
        requestStartEvent.Invoke(m_ChoiceNextNode);
    }

    public void ConnectSequencer(DialogueSequencer dialogueSequencer) {
        this.dialogueSequencer = dialogueSequencer;
        requestStartEvent.AddListener(dialogueSequencer.StartDialogueNode);
        ChoiceButton.onClick.AddListener(OnClick);
    }
}
