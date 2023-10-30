using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageInvicibility : MonoBehaviour
{
    [SerializeField] private float _invicibiltyDuration;
    private InvicibilityController _invicibilityController;

    private void Awake()
    {
        _invicibilityController = GetComponent<InvicibilityController>();
    }
    public void StartInvicibility()
    {
       _invicibilityController.StartInvincibility(_invicibiltyDuration); 
    }
}
