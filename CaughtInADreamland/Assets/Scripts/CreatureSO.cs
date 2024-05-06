using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CreatureSO")]
public class CreatureSO : ScriptableObject
{
    public int health;
    public float speed;
    public int numAntiTrapDevices;
    public int soulsCollected;
    //float stamina;
}
