using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoint : MonoBehaviour
{
    [SerializeField] public GameObject[] Bullet; // Mảng các itemDrop
    // tỉ lệ rơi đồ của pistolbullet
    [SerializeField] private float ratePistolBullet; //tỉ lệ rơi cao nhất
    [SerializeField] private float rateAkBullet;//tỉ lệ rơi cao thứ 2 
    [SerializeField] private float rateShotgunBullet;//tỉ lệ rơi thấp nhất
    [SerializeField] private float rateDrop;//tỉ lệ rơi thấp nhất
    private List<GameObject> droppedItems = new List<GameObject>();



    private void OnDestroy()
    {
        foreach (var item in droppedItems)
        {
            Destroy(item);
        }
    }


    public void CreateItem(Vector3 _potition)
    {
        // Kiểm tra xem có rơi item hay không
        if (ShouldDropItem())
        {
            // Tạo item drop dựa trên tỉ lệ đã định
            DropItem(_potition);
        }
    }


    private bool ShouldDropItem()
    {
        // Tạo một giá trị ngẫu nhiên từ 0 đến 1
        float randomValue1 = Random.value;

        // Kiểm tra xem giá trị ngẫu nhiên có nằm trong tỉ lệ rơi của bất kỳ item nào không
        if (randomValue1 >= rateDrop)
        {
            return true;
        }

        return false;
    }

    private void DropItem(Vector3 potition)
    {

        float randomValue2 = Random.value;
        // Xác định item sẽ được rơi dựa trên giá trị ngẫu nhiên
        GameObject itemToDrop = null;

        if (randomValue2 >= rateAkBullet && randomValue2 <= ratePistolBullet)
        {
            itemToDrop = Bullet[0]; // pistolbullet
        }
        else if (randomValue2 >= rateShotgunBullet && randomValue2 <= rateAkBullet)
        {
            itemToDrop = Bullet[1]; // akbullet
        }
        else if (randomValue2 <= rateShotgunBullet)
        {
            itemToDrop = Bullet[2]; // shotgunbullet
        }

        // Kiểm tra xem itemToDrop có tồn tại hay không
        if (itemToDrop != null)
        {
            // Tạo item drop tại vị trí hiện tại của enemy
            GameObject droppedItem = Instantiate(itemToDrop, potition, Quaternion.identity);
            droppedItems.Add(droppedItem); // Thêm item đã rơi vào danh sách
        }

    }
}
