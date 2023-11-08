using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomPig : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GameObject pigPrefab;
    private void Start()
    {
        CreateRandomPigs(7, 10);
    }

    public void CreatePig(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        Vector3 spawnPosition = tilemap.GetCellCenterWorld(cellPosition);

        Instantiate(pigPrefab, spawnPosition, Quaternion.identity);
    }

    public void CreateRandomPigs(int minCount, int maxCount)
    {
        int pigCount = Random.Range(minCount, maxCount + 1);

        for (int i = 0; i < pigCount; i++)
        {
            Vector3 randomWorldPosition = tilemap.GetCellCenterWorld(GetRandomCellPosition());
            CreatePig(randomWorldPosition);
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
