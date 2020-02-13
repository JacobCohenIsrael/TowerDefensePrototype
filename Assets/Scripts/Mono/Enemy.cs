using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int maxHealth;

    private int currentHealth;
    private Transform[] waypoints;
    private Animator myAnimator;
    private int currentWaypointIndex;
    private float originalXScale;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.Play("run");
        currentWaypointIndex = 0;
        currentHealth = maxHealth;
        originalXScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, Time.deltaTime * moveSpeed);
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.01f && currentWaypointIndex + 1 < waypoints.Length)
        {
            currentWaypointIndex++;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetWaypoints(Transform[] waypoints)
    {
        this.waypoints = waypoints;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject, 0.25f);
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    private void Look()
    {
        Vector2 direction = waypoints[currentWaypointIndex].position;
        if (direction.x > transform.position.x) // To the right
        {
            transform.localScale = new Vector3(originalXScale, transform.localScale.y, transform.localScale.z);

        }
        else if (direction.x < transform.position.x) // To the left
        {
            transform.localScale = new Vector3(originalXScale * -1, transform.localScale.y, transform.localScale.z);

        }
    }
}
