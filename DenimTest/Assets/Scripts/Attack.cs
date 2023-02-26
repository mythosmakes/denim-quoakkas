using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public PlayerMove playerBod;
    public bool alreadyAttacked;


    private void Start()
    {
        alreadyAttacked = false;
    }

    public void AttackRange()
    {
        alreadyAttacked = true;
    }

    public void DoneAttacking()
    {
        alreadyAttacked = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !alreadyAttacked)
        {
            playerBod.TakeDamage(1);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && !alreadyAttacked)
        {
            playerBod.TakeDamage(1);
        }
    }
}
