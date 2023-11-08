using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockController : MonoBehaviour
{
    public UnityEvent OnRockChanged;
    public int Rock { get; private set; }
    public void RockChange(int amount)
    {
        Rock = amount;
        OnRockChanged.Invoke();
    }
}
