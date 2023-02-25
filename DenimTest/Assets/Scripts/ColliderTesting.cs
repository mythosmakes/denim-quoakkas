using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTesting : MonoBehaviour
{
    public EnemyAI enemy;
    public GameObject flashlight;

    public void OnCollisionEnter(Collision attack)
    {
        Debug.Log("aaaaa");
    }

    public void OnCollisionStay(Collision present)
    {
        Debug.Log("yyyyy");
    }
}
