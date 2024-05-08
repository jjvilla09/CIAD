using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDialogueChoiceController : MonoBehaviour
{
    [SerializeField] DialogueEventSO sequencer_channel;
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
        ChoiceButton = GetComponent<Button>();
        ChoiceButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        sequencer_channel.onDialogueStart.Invoke(m_ChoiceNextNode);
    }
}
