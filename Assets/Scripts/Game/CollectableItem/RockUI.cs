using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RockUI : MonoBehaviour
{
    private TMP_Text RockQuantity;

    // Start is called before the first frame update
    void Start()
    {
        RockQuantity = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    public void UpdateRock(RockController rockController)
    {
        RockQuantity.text = $"Rock: {GameManager.rock}";
    }
}
