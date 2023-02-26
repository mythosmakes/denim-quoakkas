using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActive : MonoBehaviour
{
    public GameObject lever;
    public PlayerMove playerScript;


    public void Activate()
    {
        playerScript.Plates();
        lever.SetActive(false);
    }
}
