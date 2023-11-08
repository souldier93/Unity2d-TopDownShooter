using UnityEngine;

public class HealTower : MonoBehaviour
{

    private SpriteRenderer mainTowerRenderer;
    private Color originalColor;

    private void Start()
    {
        mainTowerRenderer = GetComponent<SpriteRenderer>();
        originalColor = mainTowerRenderer.color;
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            mainTowerRenderer.color = new Color(1f, 1f, 1f, 0.9f); // Màu trắng mờ
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            mainTowerRenderer.color = originalColor; // Màu trắng mờ
        }
    }
}