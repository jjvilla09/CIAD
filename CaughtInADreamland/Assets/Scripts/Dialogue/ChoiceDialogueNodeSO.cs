using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class DialogueChoice
{
    public string choice_preview;
    public DialogueNodeSO choice_node;
}

[CreateAssetMenu(menuName = "ScriptableObject/ChoiceDialogueNodeSO")]
public class ChoiceDialogueNodeSO : DialogueNodeSO
{
    public DialogueChoice[] choices;

    public override bool CanBeFollowedByNode(DialogueNodeSO node) {

        return choices.Any(x => x.choice_node == node);
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}
