using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCanPick : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public GameObject item;
    public GameObject[] itemIgnore;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        item = GetComponent<GameObject>();
        Physics2D.IgnoreLayerCollision(6, 7,true);
    }
}