using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public Animator camAnimate;
    public PlayerMove player;

    private void Update()
    {
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                camAnimate.SetTrigger("walk");
            }

            else
            {
                camAnimate.SetTrigger("idle");
            }
        }
    }
}
