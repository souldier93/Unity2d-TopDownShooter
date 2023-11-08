


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    private ItemPoint ItemPoint;
    private Vector3 enemyPosition; // Lưu giữ vị trí của gameObject
    public void DestroyEnemy(float delay)
    {
        enemyPosition = transform.position; // Lưu trữ vị trí trước khi hủy
        Destroy(gameObject, delay);
        ItemPoint = FindObjectOfType<ItemPoint>(); // Tìm đối tượng ItemPoint có sẵn trong Scene
        if (ItemPoint != null)
        {
            ItemPoint.CreateItem(enemyPosition,1);
        }
        else
        {
            Debug.LogError("ItemPoint not found in the scene.");
        }
    }

    public void DestroyPig(float delay)
    {
        enemyPosition = transform.position; // Lưu trữ vị trí trước khi hủy
        Destroy(gameObject, delay);
        ItemPoint = FindObjectOfType<ItemPoint>(); // Tìm đối tượng ItemPoint có sẵn trong Scene
        if (ItemPoint != null)
        {
            ItemPoint.CreateItem(enemyPosition,2);
        }
        else
        {
            Debug.LogError("ItemPoint not found in the scene.");
        }
    }

    public void DestroyCow(float delay)
    {
        enemyPosition = transform.position; // Lưu trữ vị trí trước khi hủy
        Destroy(gameObject, delay);
        ItemPoint = FindObjectOfType<ItemPoint>(); // Tìm đối tượng ItemPoint có sẵn trong Scene
        if (ItemPoint != null)
        {
            ItemPoint.CreateItem(enemyPosition, 3);
        }
        else
        {
            Debug.LogError("ItemPoint not found in the scene.");
        }
    }
}
