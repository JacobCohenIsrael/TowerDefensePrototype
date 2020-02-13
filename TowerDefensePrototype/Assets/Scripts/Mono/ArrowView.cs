using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowView : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float destroySelfDistance = 0.5f;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(Vector3.RotateTowards(initialPosition, targetPosition, moveSpeed * Time.deltaTime, moveSpeed * Time.deltaTime));
        if (Vector3.Distance(transform.position, targetPosition) < destroySelfDistance)
        {
            Destroy(gameObject);
        }
    }
}
