using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureplates : MonoBehaviour
{
    public GameObject trigger;

    void Start()
    {
        trigger.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerMove score = other.gameObject.GetComponent<PlayerMove>();
        if(score != null)
        {
            score.Plates(1);
        }

        Debug.Log("land");
        trigger.SetActive(false);
    } 
}
