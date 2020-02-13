using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowView : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float destroySelfDistance = 0.5f;
    [SerializeField] private int projectileDamage = 20;

    public void SetTargetTransform(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
        RotateToTarget();
        if (Vector3.Distance(transform.position, targetTransform.position) < destroySelfDistance)
        {
            Enemy enemy = targetTransform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(projectileDamage);
            }
            Destroy(gameObject);
        }
    }

    private void RotateToTarget()
    {
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        transform.eulerAngles = new Vector3(0, 0, n);
    }
}
