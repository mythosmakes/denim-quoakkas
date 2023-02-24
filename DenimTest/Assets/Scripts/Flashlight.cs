using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public EnemyAI enemy;

    public void OnCollisionEnter(Collision attack)
    {
        Debug.Log("fjhsgd");

        if (attack.gameObject.tag == "Enemy")
        {
            enemy.Stun();
            Debug.Log("Stuna");
        }
    }

    public void OnCollisionStay(Collision present)
    {
        if (present.gameObject.tag == "Enemy")
        {
            enemy.Stun();
            Debug.Log("Stunb");
        }
    }
}
