using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollect : MonoBehaviour
{
    private int BulletAdd = 10;
    private int HealthItemAdd = 1;
    private MeatController MeatController;
    private SteakController steakController;
    private void Start()
    {
        MeatController = GetComponent<MeatController>();
        steakController = GetComponent<SteakController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AkBullet"))//item bullet
        {
            GameManager.akBulletCount += BulletAdd;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("PistolBullet"))
        {
            GameManager.pistolBulletCount += BulletAdd;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ShotgunBullet"))
        {
            GameManager.shotgunBulletCount += BulletAdd;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Meat"))//item heal
        {
            GameManager.meat += HealthItemAdd;
            MeatController.MeatChange(GameManager.meat);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Steak"))
        {
            GameManager.steak += HealthItemAdd;
            steakController.SteakChange(GameManager.meat);
            Destroy(collision.gameObject);
        }
    }
}
