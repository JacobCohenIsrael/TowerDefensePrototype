using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    public Transform[] Waypoints { get { return waypoints; } }
}
