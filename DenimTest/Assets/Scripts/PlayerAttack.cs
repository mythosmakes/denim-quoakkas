using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Attacking
    public float timeBetweenAttacks;
    public float attackCooldown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenAttacks <= 0)
        {
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("attack");
                //timeBetweenAttacks = attackCooldown;
            }

        }

        else
        {
            Debug.Log("hit");
            //timeBetweenAttacks -= Time.deltaTime;
        }
    }
}
