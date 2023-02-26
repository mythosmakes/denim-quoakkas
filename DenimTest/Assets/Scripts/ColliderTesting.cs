using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTesting : MonoBehaviour
{
    public EnemyAI enemy;
    public GameObject flashlight;

    public void OnTriggerEnter()
    {
        Debug.Log("aaaaa");
    }

    public void OnTriggerStay()
    {
        Debug.Log("yyyyy");
    }
}
