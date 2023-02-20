using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject health;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("collide");

        if (col.gameObject.tag == "Enemy")
        {

        }

        //HealthManager healthScore = gameObject.GetComponent<HealthManager>();
        //if(healthScore != null)
        {
            //Debug.Log("activate");
            //healthScore.TakeDamage(1);
        }

    }
}
