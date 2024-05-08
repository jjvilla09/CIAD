using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandlerChannel : MonoBehaviour
{
    [SerializeField] VoidDialogueEventSO void_dialogue_channel;
    [SerializeField] PlayerInputHandler playerInputHandler;

    private void Awake() {
        void_dialogue_channel.onDialogueStart += TurnOffPlayerMovement;
        void_dialogue_channel.onDialogueEnd += TurnOnPlayerMovement;
    }

    private void OnDestroy() {
        void_dialogue_channel.onDialogueStart -= TurnOffPlayerMovement;
        void_dialogue_channel.onDialogueEnd -= TurnOnPlayerMovement;
    }
    
    void TurnOffPlayerMovement() {
        playerInputHandler.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    void TurnOnPlayerMovement() {
        playerInputHandler.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
}
