using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeatController : MonoBehaviour
{
    public UnityEvent OnMeatChanged;
    public int Meat { get; private set; }
    public void MeatChange(int amount)
    {
        Meat = amount;
        OnMeatChanged.Invoke();
    }
}
