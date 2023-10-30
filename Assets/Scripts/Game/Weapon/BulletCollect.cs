using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollect : MonoBehaviour
{
    private int BulletAdd = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AkBullet"))
        {
            BulletAdd = 10;
            GameManager.akBulletCount += BulletAdd;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("PistolBullet"))
        {
            BulletAdd = 10;
            GameManager.pistolBulletCount += BulletAdd;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ShotgunBullet"))
        {
            BulletAdd = 10;
            GameManager.shotgunBulletCount += BulletAdd;
            Destroy(collision.gameObject);
        }
    }
}
