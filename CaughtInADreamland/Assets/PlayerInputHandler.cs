using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] Creature jay;
    [SerializeField] DoorController door;
    Vector3 input;
    [SerializeField] FadeTransitionController ftc;
    [SerializeField] string nextSceneName;

    // Update is called once per frame
    void Update()
    {
        // Player Movement Variables
        input = Vector3.zero;

        // Player Movement
        if(Input.GetKey(KeyCode.W)) {
            input.y = 1;
        }
        if(Input.GetKey(KeyCode.S)) {
            input.y = -1;
        }
        if(Input.GetKey(KeyCode.A)) {
            input.x = -1;
        }
        if(Input.GetKey(KeyCode.D)) {
            input.x = 1;
        }

        jay.MoveCreature(input);

        // Open Door Check
        if(door.getIsPlayerInRange() && Input.GetKeyDown(KeyCode.E) && jay.getHasGem()) {
            ftc.FadeToColor(nextSceneName);
        }
    }

    // public void OpenDoorHandle(string nextSceneName) {
    //     if(door.getIsPlayerInRange() && Input.GetKeyDown(KeyCode.E) && jay.getHasGem()) {
    //         ftc.FadeToColor(nextSceneName);
    //     }
    // }
    // public void EHandler(){
        
    //     StartCoroutine(EHandlerRoutine());
    //     IEnumerator EHandlerRoutine(){
            
    //         while(door.isPlayerInRange){
    //             yield return null;
    //             if()
    //         }
            
    //     }
    // }
}
