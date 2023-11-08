using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WoodController : MonoBehaviour
{
    public UnityEvent OnWoodChanged;
    public int Wood { get; private set; }
    public void WoodChange(int amount)
    {
        Wood = amount;
        OnWoodChanged.Invoke();
    }
}
