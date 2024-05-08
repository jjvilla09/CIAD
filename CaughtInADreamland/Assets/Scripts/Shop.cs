using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] Canvas shopCanvas;
    [SerializeField] TextMeshProUGUI helperText;

    [Header("Player")]
    [SerializeField] Creature player;

    [Header("Player Soul Counter")]
    [SerializeField] SoulCounter playerSoulCounter;

    [Header("Shop prices")]
    int healthPrice = 40;
    int speedPrice = 50;
    int antiTrapDevicePrice = 150;
    int topHatPrice = 200;

    // Start is called before the first frame update
    void Start()
    {
        shopCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop() {
        shopCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    public void CloseShop() {
        shopCanvas.enabled = false;
        Time.timeScale = 1f;
    }

    public void BuyHealth() {
        int playerLives = player.GetLives();

        // checks if player has max health
        if(playerLives >= 3) {
            helperText.text = "Health is full";
        } else
        if(CurrencyChecker(healthPrice)) {
            BuyItem(healthPrice);
            player.AddLife();
        }
    }

    public void BuySpeed() {
        // TODO - check is player has max speed
        if(CurrencyChecker(speedPrice)) {
            BuyItem(speedPrice);
        }
    }

    public void BuyAntiTrapDevice() {
        // TODO - check if player has max anti trap devices
        if(CurrencyChecker(antiTrapDevicePrice)) {
            BuyItem(antiTrapDevicePrice);
        }
    }

    public void BuyTopHat() {
        // TODO - checks if top hat is already owned
        if(CurrencyChecker(topHatPrice)) {
            BuyItem(topHatPrice);
        }
    }

    void BuyItem(int price) {
        int playerTotalSouls = SoulCounter.singleton.GetSoulsCollected();
        SoulCounter.singleton.SetSoulsCollected(playerTotalSouls - price);
        helperText.text = "Item has been bought!";
    }

    bool CurrencyChecker(int price) {
        int playerTotalSouls = SoulCounter.singleton.GetSoulsCollected();
        if(playerTotalSouls < price) {
            helperText.text = "Not enough souls";
            return false;
        }

        return true;
    }
}
