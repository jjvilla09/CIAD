using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField] private FadeTransitionController ftc;
    
    public void Back() {
        ftc.FadeToColor("MainMenu");
    }

    public void ApplySettings() {
        // TODO - Apply settings
    }
}
