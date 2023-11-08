using Goldmetal.UndeadSurvivor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeatUI : MonoBehaviour
{
    private TMP_Text MeatQuantity;

    // Start is called before the first frame update
    void Start()
    {
        MeatQuantity = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    public void UpdateMeat(MeatController meatController)
    {
        MeatQuantity.text = $"Meat: {GameManager.meat}";
    }
}
