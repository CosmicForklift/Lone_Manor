using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

public class WoodenBeam : NetworkBehaviour
{
    private BarredWoodenDoor _barredDoorScript;

    private void Start()
    {
        _barredDoorScript = GetComponentInParent<BarredWoodenDoor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.CompareTag("Axe"))
        {
            BreakRPC();

        }
    }

    [Rpc(SendTo.ClientsAndHost)]
    public void BreakRPC()
    {
        Debug.Log("Triggered by Enemy");
                    _barredDoorScript.count++; 
                    _barredDoorScript.OpenAttempt();
                    Destroy(gameObject);
    }
    
    
    
}
