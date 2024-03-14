using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] Creature jay;
    Vector3 input;

    // [Header("Player Stats")]
    // [SerializeField] float speed;


    // [Header("")]





    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        input = Vector3.zero;
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

        jay.movePlayer(input);
    }
}
