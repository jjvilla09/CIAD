using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueNodeSO : ScriptableObject
{
    public NarrationLineSO narration_line;

    public abstract bool CanBeFollowedByNode(DialogueNodeSO node);
    public abstract void Accept(DialogueNodeVisitor visitor);
}
