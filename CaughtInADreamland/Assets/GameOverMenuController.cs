using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenuController : MonoBehaviour
{
    [SerializeField] FadeTransitionController ftc;
    public void MainMenu() {
        ftc.FadeToColor("MainMenu");
    }
}
