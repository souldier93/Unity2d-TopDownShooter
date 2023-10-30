using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _healthbarForegroundImage;

    public void UpdateHealthBar(HealthController healthController)
    {
        _healthbarForegroundImage.fillAmount = healthController.RemainingHealthPercentage;
    }
}
