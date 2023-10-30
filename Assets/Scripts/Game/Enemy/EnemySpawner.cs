

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefabs; // Mảng các enemyPrefab
    [SerializeField] public float minimumSpawnTime;
    [SerializeField] public float maximumSpawnTime;
    private float _timeUntilSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        setTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length); // Chọn ngẫu nhiên một enemyPrefab từ mảng
            Instantiate(enemyPrefabs[randomIndex], transform.position, Quaternion.identity);
            setTimeUntilSpawn();
        }
    }

    private void setTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}