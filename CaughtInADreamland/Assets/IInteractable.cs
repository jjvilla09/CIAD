using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool ProximityCheck();
    Vector3 GetPosition();
    void Interact();
    void ShowHelperText();
}
