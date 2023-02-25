using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public EnemyAI enemy;
    public GameObject flashlight;

    public void OnCollisionEnter(Collision attack)
    {
        Debug.Log("aaaaa");

        if (attack.gameObject.tag == "Enemy")
        {
            enemy.Stun();
            Debug.Log("Stuna");
        }
    }

    public void OnCollisionStay(Collision present)
    {
        Debug.Log("yyyyy");

        if (present.gameObject.tag == "Enemy")
        {
            enemy.Stun();
            Debug.Log("Stunb");
        }
    }
}
