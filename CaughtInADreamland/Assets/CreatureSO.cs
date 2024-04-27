using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CreatureSO")]
public class CreatureSO : ScriptableObject
{
    public int health;
    public float speed;
    public int numAntiTrapDevices;
    //float stamina;
}
