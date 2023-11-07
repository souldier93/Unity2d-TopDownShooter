
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;

//public class FixedEnemyMovement : MonoBehaviour
//{
//    private Transform target;// target player
//    private Transform mainTower;// target tower
//    public float speed;
//    private bool isChasing = false;
//    public float chasingDistance = 5f; // Khoảng cách để enemy bắt đầu đuổi theo player

//    private Animator animator;
//    void Start()
//    {
//        animator = GetComponent<Animator>();
//        target = GameObject.FindGameObjectWithTag("Player").transform;
//        mainTower = GameObject.FindGameObjectWithTag("mainTower").transform;
//    }

//    void Update()
//    {
//        if (!isChasing)
//        {
//            CheckDistanceToPlayer();
//        }
//        else
//        {
//            ChasePlayer();
//        }
//    }

//    private void CheckDistanceToPlayer()
//    {
//        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
//        if (distanceToPlayer <= chasingDistance)
//        {
//            isChasing = true;
//            //animator.SetBool("isRunning", true);
//        }
//    }

//    private void ChasePlayer()
//    {
//        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
//        if (distanceToPlayer > chasingDistance)
//        {
//            isChasing = false;
//            return;
//        }

//        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
//        if (target.position.x > transform.position.x)
//        {
//            transform.rotation = Quaternion.Euler(0, 0, 0); // Quay sang phải
//        }
//        else if (target.position.x < transform.position.x)
//        {
//            transform.rotation = Quaternion.Euler(0, 180, 0); // Quay sang trái
//        }
//    }
//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedEnemyMovement : MonoBehaviour
{
    private Transform target; // target player
    private Transform mainTower; // target tower
    public float speed;
    private bool isChasingPlayer = false;
    private bool isChasingTower = false;
    //public float chasingDistance = 5f; // Khoảng cách để enemy bắt đầu đuổi theo player

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mainTower = GameObject.FindGameObjectWithTag("MainTower").transform;
    }

    void Update()
    {
        CheckDistanceToPlayer();
        if (isChasingPlayer)
        {
            ChasePlayer();
        }
        else if (isChasingTower)
        {
            ChaseTower();
        }
    }

    private void CheckDistanceToPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        float distanceToTower = Vector2.Distance(transform.position, mainTower.position);

        if (distanceToPlayer <= distanceToTower)
        {
            isChasingPlayer = true;
            isChasingTower = false;
        }
        else if (distanceToTower <= distanceToPlayer)
        {
            isChasingPlayer = false;
            isChasingTower = true;
        }
    }

    private void ChasePlayer()
    {
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

    private void ChaseTower()
    {
        transform.position = Vector2.MoveTowards(transform.position, mainTower.position, speed * Time.deltaTime);
        if (mainTower.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Quay sang phải
        }
        else if (mainTower.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Quay sang trái
        }
    }
}




