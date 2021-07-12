using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool isActive;
    private Rigidbody2D platformRigidbody;
    private int currentWaypoint;
    private Vector2 currentDirection;
    [SerializeField] private Vector2[] waypoints;
    [SerializeField] private float speed;

    private void Start()
    {
        platformRigidbody = GetComponent<Rigidbody2D>();
        currentWaypoint = 0;
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void Activate()
    {
        isActive = !isActive;
    }
    private void Move()
    {
        if (isActive)
        {
            Vector2 destination = waypoints[currentWaypoint] - (Vector2)transform.position;
            if (destination.magnitude <= 0.01f)
            {
                currentWaypoint++;
                if (currentWaypoint >= waypoints.Length)
                {
                    currentWaypoint = 0;
                }
            }
            currentDirection = destination.normalized;
        }
        else if (!isActive)
        {
            currentDirection = Vector2.zero;
        }
        platformRigidbody.velocity = currentDirection * speed * Time.deltaTime;
    }
}
