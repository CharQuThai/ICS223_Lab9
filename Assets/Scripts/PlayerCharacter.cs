using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    private int health;

    private int maxHealth = 5;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
    }

    public void Hit()
    {
       


        health -= 1;

        float healthPercentage = (float)health / maxHealth;

        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercentage);

        Debug.Log("Health: " + health);

        Color healthColour = Color.Lerp(Color.green, Color.red, healthPercentage);
        uiController.healthBar.color = healthColour;

        if (health == 0)
        {
            Debug.Break();
        }
    }
}
