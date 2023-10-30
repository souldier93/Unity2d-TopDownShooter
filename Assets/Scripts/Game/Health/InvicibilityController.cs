//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InvicibilityController : MonoBehaviour
//{
//    private HealthController _healthController;
//    private bool invicible;
//    private Color col;
//    private SpriteRenderer character;


//    private void Awake()
//    {
//        _healthController = GetComponent<HealthController>();
//        character = GetComponent<SpriteRenderer>();
//        col = character.color;
//    }

//    public void StartInvicibility(float invincibilityDuration)
//    {
//        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
//    }

//    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
//    {
//        _healthController.IsInvicible = true;
//        col.a = .2f;
//        character.color = col;
//        yield return new WaitForSeconds(invincibilityDuration);
//        col.a = 1;
//        character.color = col;
//        _healthController.IsInvicible = false;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvicibilityController : MonoBehaviour
{
    private HealthController _healthController;
    private bool invincible;
    private Color originalColor;
    private SpriteRenderer character;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
        character = GetComponent<SpriteRenderer>();
        originalColor = character.color;
    }

    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        _healthController.IsInvicible = true;

        // Nhấp nháy màu đỏ
        StartCoroutine(BlinkCoroutine());

        yield return new WaitForSeconds(invincibilityDuration);

        _healthController.IsInvicible = false;
        character.color = originalColor;
    }

    private IEnumerator BlinkCoroutine()
    {
        Color blinkColor = Color.red;
        float blinkInterval = 0.2f;
        int blinkCount = 5;

        for (int i = 0; i < blinkCount * 2; i++)
        {
            character.color = (i % 2 == 0) ? blinkColor : originalColor;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}