using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorController : MonoBehaviour
{
    [SerializeField] Creature jay;
    [SerializeField] TextMeshProUGUI helperText;
    string helperString = "Press E to open";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            helperText.text = helperString;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            helperText.text = "";
        }
    }
}
