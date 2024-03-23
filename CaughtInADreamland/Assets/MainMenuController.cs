using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private FadeTransitionController ftc;
    
    public void Play() {
        ftc.FadeToColor("Prototype");
    }

    public void Quit() {
        Application.Quit();
    }
}
