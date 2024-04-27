using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthSystem<T>
{
    T health { get; set; }
    void AddHealth(T value);
    void SubtractHealth(T value);

}
