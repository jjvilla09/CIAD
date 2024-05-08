using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRendererConfig;

public abstract class DialogueNodeSO : ScriptableObject
{
    public TextMovementEffectState textMovementEffectState;
    public TextColorEffectState textColorEffectState;
    public TextModeState textModeState;

    public NarrationLineSO narration_line;

    public abstract bool CanBeFollowedByNode(DialogueNodeSO node);
    public abstract void Accept(DialogueNodeVisitor visitor);
}
