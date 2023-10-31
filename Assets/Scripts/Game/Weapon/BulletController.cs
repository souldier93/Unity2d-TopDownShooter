using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletController : MonoBehaviour
{
    public UnityEvent OnBulletChanged;
    public int Bullet { get; private set; }
    public void BulletChange(int amount)
    {
        Bullet = amount;
        OnBulletChanged.Invoke();
    }
}
