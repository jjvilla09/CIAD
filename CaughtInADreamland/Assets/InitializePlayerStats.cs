using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePlayerStats : MonoBehaviour
{
    [Header("Player Stat Scriptable Object")]
    [SerializeField] CreatureSO playerStatsSO;

    [Header("Beginning Player Stats")]
    [SerializeField] int health;
    [SerializeField] int currency;
    [SerializeField] int AntiTrapDeviceCount;
    [SerializeField] float speed;

    // -------------- Initialize player stats in the beginning of the game --------------- //
    private void Awake() {
        playerStatsSO.health = health;
        playerStatsSO.soulsCollected = currency;
        playerStatsSO.numAntiTrapDevices = AntiTrapDeviceCount;
        playerStatsSO.speed = speed;
    }
}
