
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FixedEnemyMovement : MonoBehaviour
{
    private Transform target;
    public float speed;
    private bool isChasing = false;
    public float chasingDistance = 5f; // Khoảng cách để enemy bắt đầu đuổi theo player

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isChasing)
        {
            CheckDistanceToPlayer();
        }
        else
        {
            ChasePlayer();
        }
    }

    private void CheckDistanceToPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if (distanceToPlayer <= chasingDistance)
        {
            isChasing = true;
            //animator.SetBool("isRunning", true);
        }
    }

    private void ChasePlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if (distanceToPlayer > chasingDistance)
        {
            isChasing = false;
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (target.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Quay sang phải
        }
        else if (target.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Quay sang trái
        }
    }
}











