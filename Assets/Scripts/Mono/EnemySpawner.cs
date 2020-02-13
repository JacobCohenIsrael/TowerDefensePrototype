using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Enemy[] enemies;

    [SerializeField] Transform spawnTransform;

    [SerializeField] EnemyPath enemyPath;

    public static List<Enemy> Enemies { get; set; }

    void Start()
    {
        Enemies = new List<Enemy>();
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = Instantiate<Enemy>(enemies[i], spawnTransform);
            enemy.SetWaypoints(enemyPath.Waypoints);
            Enemies.Add(enemy);
        }
    }
}
