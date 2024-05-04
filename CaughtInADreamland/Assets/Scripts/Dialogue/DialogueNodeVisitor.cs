
public interface DialogueNodeVisitor
{
    void Visit(BasicDialogueNodeSO node);
    void Visit(ChoiceDialogueNodeSO node);
}
