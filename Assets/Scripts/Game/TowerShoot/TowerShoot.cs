using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;

    private GameObject targetEnemy;
    private float fireRateTimer;

    private void Start()
    {
        FindTargetEnemy();
    }

    private void Update()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer >= fireRate)
        {
            FindTargetEnemy(); // Tìm lại kẻ địch mỗi lần bắn
            if (targetEnemy != null)
            {
                FireBullet();
                fireRateTimer = 0f;
            }
        }
    }

    private void FindTargetEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                targetEnemy = enemy;
            }
        }
    }

    private void FireBullet()
    {
        Vector2 direction = targetEnemy.transform.position - firePoint.position;
        direction.Normalize();

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        BulletTower bulletScript = bullet.GetComponent<BulletTower>();
        bulletScript.SetRotation(direction);

        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction * bulletSpeed;
    }
}