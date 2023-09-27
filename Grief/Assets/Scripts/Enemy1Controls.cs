using UnityEngine;
using UnityEngine.UI;
using TarodevController; // Make sure to include the necessary namespace if not already included

public class Enemy1Controls : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public int damageOnHit = 1;

    private bool movingRight = false;
    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        // Move in the current direction
        Vector3 moveDirection = movingRight ? Vector3.right : Vector3.left;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                // Reduce player hit points
                gameManager.PlayerHit(damageOnHit);
            }
        }

        // Switch direction if the trigger is hit
        if (other.isTrigger)
        {
            movingRight = !movingRight;
        }
    }
}
