using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide");

        HealthManager healthScore = gameObject.GetComponent<HealthManager>();
        if(healthScore != null)
        {
            Debug.Log("activate");
            healthScore.TakeDamage(1);
        }

    }
}
