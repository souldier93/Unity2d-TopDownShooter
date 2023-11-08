using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : MonoBehaviour
{
    [SerializeField] private float damageOfBullet;
    [SerializeField] private float destroyDelay = 4f; // Thời gian tồn tại trước khi tự hủy

    private float destroyTimer;

    private void Start()
    {
        destroyTimer = 0f;
    }

    private void Update()
    {
        destroyTimer += Time.deltaTime;

        if (destroyTimer >= destroyDelay)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            if (healthController != null)
            {
                healthController.TakeDamage(damageOfBullet);
            }

            Destroy(gameObject);
        }
    }

    public void SetRotation(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}