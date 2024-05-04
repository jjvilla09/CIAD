using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/NarrationLineSO")]
public class NarrationLineSO : ScriptableObject
{
    public NarrationCharacterSO narration_character;
    public string narration_text;
}
