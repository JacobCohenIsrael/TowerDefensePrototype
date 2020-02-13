using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Enemy[] enemies;

    [SerializeField] Transform spawnTransform;

    [SerializeField] EnemyPath enemyPath;
    [SerializeField] private float spawnDelay = 0.25f;

    public static List<Enemy> Enemies { get; set; }

    void Start()
    {
        Enemies = new List<Enemy>();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = Instantiate<Enemy>(enemies[i], spawnTransform);
            enemy.SetWaypoints(enemyPath.Waypoints);
            Enemies.Add(enemy);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
