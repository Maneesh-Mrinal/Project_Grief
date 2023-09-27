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
        targetPoint = endPoint; // Start by moving towards the endPoint
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (transform.position == endPoint.position)
        {
            targetPoint = startPoint; // Change direction when reaching endPoint
        }
        else if (transform.position == startPoint.position)
        {
            targetPoint = endPoint; // Change direction when reaching startPoint
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




