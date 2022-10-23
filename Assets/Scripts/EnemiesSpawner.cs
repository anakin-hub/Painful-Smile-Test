using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject ChaserPrefab;
    [SerializeField] protected GameObject ShooterPrefab;
    [SerializeField] protected List<Transform> SpawnPoints;
    [SerializeField] protected float _spawnTime;
    [SerializeField] protected bool _spawned;
    [SerializeField] protected int _randomEnemyChance;

    private void FixedUpdate()
    {
        if (!_spawned)
            StartCoroutine(Spawn());

        if (_randomEnemyChance > 10)
            _randomEnemyChance = 10;
        if (_randomEnemyChance < 2)
            _randomEnemyChance = 2;
    }

    Transform GetRandomSpawnPoint()
    {
        return SpawnPoints[Random.Range(0, SpawnPoints.Count-1)];
    }

    GameObject GetRandomEnemy()
    {
        int RandomChance = Random.Range(1, 10);

        if (RandomChance <= _randomEnemyChance)
            return ShooterPrefab;
        else
            return ChaserPrefab;
    }

    IEnumerator Spawn()
    {
        _spawned = true;
        GameObject enemy = GetRandomEnemy();
        Transform spawnpoint = GetRandomSpawnPoint();
        Instantiate(enemy, spawnpoint.position, spawnpoint.rotation);

        yield return new WaitForSeconds(_spawnTime);


        _spawned = false;
    }

    public void SetSpawnTime(float spawntime)
    {
        _spawnTime = spawntime;
    }
}
