using System.Collections;
using UnityEngine;
using TarodevController;
public class Enemy1Controls : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed = 2.0f;
    public int damageOnHit = 1;

    private Transform targetPoint;

    private void Start()
    {
        targetPoint = endPoint; // Start by moving towards the endpoint
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        // Move towards the current target point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        // Check if we have reached the current target point
        if (transform.position == targetPoint.position)
        {
            // Switch target points to create a continuous loop
            if (targetPoint == endPoint)
            {
                targetPoint = startPoint;
            }
            else
            {
                targetPoint = endPoint;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damageOnHit);
            }
        }
    }
}
