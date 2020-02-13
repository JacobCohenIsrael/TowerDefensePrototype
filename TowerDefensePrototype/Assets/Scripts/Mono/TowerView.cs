using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerView : MonoBehaviour
{
    [SerializeField] private Transform shootTransform;
    [SerializeField] private ArrowView arrowProjectile;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = MouseUtil.GetMouseWorldPosition();
            ArrowView arrow = Instantiate<ArrowView>(arrowProjectile, shootTransform.position, Quaternion.identity);
            arrow.SetTargetPosition(mousePosition);
        }
    }
}
