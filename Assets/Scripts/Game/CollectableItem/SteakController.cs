using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SteakController : MonoBehaviour
{
    public UnityEvent OnSteakChanged;
    public int Steak { get; private set; }
    public void SteakChange(int amount)
    {
        Steak = amount;
        OnSteakChanged.Invoke();
    }
}
