using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerHitPoints = 3;
    public Text hitPointsText;

    private void Start()
    {
        UpdateHitPointsText();
    }

    public void PlayerHit(int damage)
    {
        playerHitPoints -= damage;
        UpdateHitPointsText();

        if (playerHitPoints <= 0)
        {
            // Game over logic here
        }
    }

    private void UpdateHitPointsText()
    {
        if (hitPointsText != null)
        {
            hitPointsText.text = "Hit Points: " + playerHitPoints;
        }
    }
}
