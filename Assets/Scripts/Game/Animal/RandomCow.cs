using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomCow : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GameObject cowPrefab;
    private void Start()
    {
        CreateRandomCows(5, 7);
    }

    public void CreateCow(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        Vector3 spawnPosition = tilemap.GetCellCenterWorld(cellPosition);

        Instantiate(cowPrefab, spawnPosition, Quaternion.identity);
    }

    public void CreateRandomCows(int minCount, int maxCount)
    {
        int CowCount = Random.Range(minCount, maxCount + 1);

        for (int i = 0; i < CowCount; i++)
        {
            Vector3 randomWorldPosition = tilemap.GetCellCenterWorld(GetRandomCellPosition());
            CreateCow(randomWorldPosition);
        }
    }

    private Vector3Int GetRandomCellPosition()
    {
        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int randomCellPosition = new Vector3Int(
            Random.Range(bounds.min.x, bounds.max.x + 1),
            Random.Range(bounds.min.y, bounds.max.y + 1),
            bounds.min.z
        );

        return randomCellPosition;
    }
}
