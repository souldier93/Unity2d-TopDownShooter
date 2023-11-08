using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WoodUI : MonoBehaviour
{
    private TMP_Text WoodQuantity;

    // Start is called before the first frame update
    void Start()
    {
        WoodQuantity = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    public void UpdateWood(WoodController woodController)
    {
        WoodQuantity.text = $"Wood: {GameManager.wood}";
    }
}
