//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//public class HealthController : MonoBehaviour
//{
//    [SerializeField] private float _currentHealth;
//    [SerializeField] private float _maximumHealth;
//    public float RemainingHealthPercentage
//    {
//        get { return _currentHealth / _maximumHealth; }
//    }
//    public bool IsInvicible {  get; set; }

//    public UnityEvent onDied;
//    public UnityEvent onDamaged;
//    public UnityEvent onHealthChanged;

//    //fix
//    //public GameObject weaponObject; // Đối tượng vũ khí
//    //private void Start()
//    //{
//    //    weaponObject.SetActive(true); // Kích hoạt vũ khí ban đầu
//    //}
//    //--
//    public void TakeDamage(float damageAmount)
//    {
//        if(_currentHealth == 0) {
//            return;
//        }

//        if(IsInvicible)
//        {
//            return;
//        }

//        _currentHealth -= damageAmount;

//        onHealthChanged.Invoke();

//        if(_currentHealth < 0)
//        {
//            _currentHealth = 0;
//        }

//        if(_currentHealth == 0)
//        {
//            onDied.Invoke();
//            //fix
//            //Die();
//            //-
//        }
//        else
//        {
//            onDamaged.Invoke();
//        }
//    }

//    public void AddHealth(float AmountToAdd)
//    {
//        if (_currentHealth == _maximumHealth)
//        {
//            return;
//        }

//        _currentHealth += AmountToAdd;

//        onHealthChanged.Invoke();

//        if (_currentHealth > _maximumHealth)
//        {
//            _currentHealth = _maximumHealth;
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maximumHealth;

    public float RemainingHealthPercentage
    {
        get { return _currentHealth / _maximumHealth; }
    }
    public bool IsInvicible { get; set; }

    public UnityEvent onDied;
    public UnityEvent onDamaged;
    public UnityEvent onHealthChanged;

    
    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (IsInvicible)
        {
            return;
        }
        _currentHealth -= damageAmount;

        onHealthChanged.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            onDied.Invoke();
        }
        else
        {
            onDamaged.Invoke();
        }
    }

    public void AddHealth(float AmountToAdd)
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += AmountToAdd;

        onHealthChanged.Invoke();

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }
    }
}

