using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SteakUI : MonoBehaviour
{
    private TMP_Text SteakQuantity;

    // Start is called before the first frame update
    void Start()
    {
        SteakQuantity = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    public void UpdateSteak(SteakController meatController)
    {
        SteakQuantity.text = $"Steak: {GameManager.steak}";
    }
}
