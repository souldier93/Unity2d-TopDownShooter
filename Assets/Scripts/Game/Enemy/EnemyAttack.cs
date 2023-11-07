using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damageAmount;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() || collision.gameObject.CompareTag("MainTower"))
        {
            _animator.SetTrigger("isAttack1");
            var HealthController = collision.gameObject.GetComponent<HealthController>();
            HealthController.TakeDamage(_damageAmount);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _animator.ResetTrigger("isAttack1");
    }

    
}


