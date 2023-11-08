

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private float dameOfBullet;
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
        if (collision.GetComponent<FixedEnemyMovement>() || collision.GetComponent<AnimalController>())
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamage(dameOfBullet);
            Destroy(gameObject);
        }
    }


    public void SetRotation(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}