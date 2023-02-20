using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureplates : MonoBehaviour
{
    public GameObject trigger;

    public PlayerMove player;

    void Start()
    {
        trigger.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {        
        Debug.Log("land");
        player.Plates();
        trigger.SetActive(false);
    }
}
