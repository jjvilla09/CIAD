using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/BasicDialogueNodeSO")]
public class BasicDialogueNodeSO : DialogueNodeSO
{
    public DialogueNodeSO next_node;

    public override bool CanBeFollowedByNode(DialogueNodeSO node) {
        return next_node == node;
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}
