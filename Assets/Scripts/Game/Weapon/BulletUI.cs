using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletUI : MonoBehaviour
{
    private TMP_Text bulletText;

    private void Awake()
    {
        bulletText = GetComponent<TMP_Text>();
    }

    public void UpdateBullet(BulletController bulletController)
    {
        bulletText.text = $"Bullet: {bulletController.Bullet}";
    }
}
