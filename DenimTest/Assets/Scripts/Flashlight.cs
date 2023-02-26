using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public EnemyAI enemy;
    public GameObject flashlight;

    public void OnTriggerEnter(Collider attack)
    {
        if (attack.gameObject.tag == "Enemy")
        {
            enemy.Stun();           
        }
    }

    public void OnTriggerStay(Collider present)
    {
        if (present.gameObject.tag == "Enemy")
        {
            enemy.Stun();
        }
    }
}
