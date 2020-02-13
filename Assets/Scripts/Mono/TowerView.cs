using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerView : MonoBehaviour
{
    [SerializeField] private Transform shootTransform;
    [SerializeField] private ArrowView arrowProjectile;
    [SerializeField] private float towerRange;
    [SerializeField] private float shootSpeed;

    private float time = 0;


    private void Update()
    {
        time += Time.deltaTime;
        Enemy closestEnemy = GetClosestEnemy();
        if (closestEnemy != null && time > shootSpeed)
        {
            ArrowView arrow = Instantiate<ArrowView>(arrowProjectile, shootTransform.position, Quaternion.identity);
            arrow.SetTargetPosition(closestEnemy.GetPosition());
            time = 0;
        }
    }

    private Enemy GetClosestEnemy()
    {
        foreach (Enemy enemy in EnemySpawner.Enemies)
        {
            if (Vector2.Distance(transform.position, enemy.GetPosition()) < towerRange)
            {
                return enemy;
            }
        }
        return null;
    }
}
