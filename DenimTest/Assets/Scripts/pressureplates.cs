using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureplates : MonoBehaviour
{
    public GameObject trigger; 
    public PlayerMove player;

    public void StepActivation()
    {
        Debug.Log("Activate");

        player.Plates();
        trigger.SetActive(false);
    }
}
