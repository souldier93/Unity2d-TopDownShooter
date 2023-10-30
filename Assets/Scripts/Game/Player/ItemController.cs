using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public void DropWeapon()
    {
        GameObject weapon = GameObject.FindGameObjectWithTag("weapon");
        if (weapon != null)
        {
            Destroy(weapon);
        }
    }

    public void DestroyHealthBarCanvas()
    {
        GameObject healthBarCanvas = GameObject.FindGameObjectWithTag("HealthBar");
        if (healthBarCanvas != null)
        {
            Destroy(healthBarCanvas);
        }
    }
}
