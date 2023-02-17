using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("damage");
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            Debug.Log("ded");
            //death 
        }
    }

}
