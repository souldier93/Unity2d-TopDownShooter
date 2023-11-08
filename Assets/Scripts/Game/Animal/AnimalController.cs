using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public float moveSpeed = 0f;
    public float changeDirectionInterval = 2f;
    private Vector2 moveDirection;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ChangeDirection());
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Quay sang phải
        }
        else if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Quay sang trái
        }
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            StartCoroutine(BoostSpeed());
        }
    }

    private IEnumerator BoostSpeed()
    {
        moveSpeed = 5f;
        yield return new WaitForSeconds(5f);
        moveSpeed = 0f;
    }
}