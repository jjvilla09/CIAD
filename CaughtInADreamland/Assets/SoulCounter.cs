using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoulCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI soulCounterText;
    public static SoulCounter singleton;
    int soulsCollected = 0;

    void Awake(){
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }
    void Start(){

    }
    
    public void RegisterSoul(int points = 1){
        soulsCollected += points;
        soulCounterText.text = soulsCollected.ToString();
    }

    public int GetSoulsCollected() {
        return soulsCollected;
    }

    public void SetSoulsCollected(int value) {
        soulsCollected = value;
        soulCounterText.text = soulsCollected.ToString();
    }
}
