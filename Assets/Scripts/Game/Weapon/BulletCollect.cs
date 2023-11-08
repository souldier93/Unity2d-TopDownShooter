using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletCollect : MonoBehaviour
{
    private int BulletAdd = 10;
    private int HealthItemAdd = 1;
    private MeatController MeatController;
    private SteakController steakController;
    private WoodController woodController;
    private RockController rockController;
    private void Start()
    {
        MeatController = GetComponent<MeatController>();
        steakController = GetComponent<SteakController>();
        woodController = GetComponent<WoodController>();
        rockController = GetComponent<RockController>();

        woodController.WoodChange(GameManager.wood);
        rockController.RockChange(GameManager.rock);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MainTower"))
        {
            if (Keyboard.current[Key.E].wasPressedThisFrame && GameManager.wood >= 100 && GameManager.rock >= 100)
            {
                GameManager.wood -= 100;
                GameManager.rock -= 100;
                woodController.WoodChange(GameManager.wood);
                rockController.RockChange(GameManager.rock);
                var HealthController = collision.gameObject.GetComponent<HealthController>();
                HealthController.AddHealth(100);
            }
        }
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
