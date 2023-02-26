using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Transform cam;
    public float playerActivateDistance;
    public pressureplates interact;
    bool active = false;

    void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);

        if(Input.GetKeyDown(KeyCode.F) && active == true)
        {
            Debug.Log("Send");

            if (hit.transform.GetComponent<pressureplates>() != null)
            {
                Debug.Log("Recieved");
                interact.StepActivation();
            }
        }
    }
}