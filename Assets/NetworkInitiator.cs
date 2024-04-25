using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will be triggered whenever the creation of the lobby happens
//When that triggers a 5 second timer is started, where at the end of the timer all of the objcts that should be Player 2 controlled are triggered

public class NetworkInitiator : MonoBehaviour
{
    //Set this to true when objects should be shifted to their correct starting player 
    public bool setObjectStatus = false; 
    
    public void Initiate()
    {
        Debug.Log("Triggered");
        StartCoroutine(WaitForConnection());
    }

    //Wait 5 seconds before initiating player 2 objects
    IEnumerator WaitForConnection()
    {
        yield return new WaitForSeconds(5);
        setObjectStatus = true; 
    }
}
