using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    [SerializeField] public Image healthBar;


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

       // Color healthColour = Color.Lerp(Color.green, Color.red, healthPercentage);
        //healthBar.color = healthColour;

        if (health == 0)
        {
            Debug.Break();
        }
    }
}
