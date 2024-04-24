using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Windows.WebCam;


public class AuthorityManager : NetworkBehaviour
{
    //This script will set the starting ownership value to the appropriate player based upon where the item spawns
    //This script will transfer ownership of the object upon contact with a Chute
    
    //Create the nessecary variable associated with network stuffs
    private NetworkObject _Network;

    //This value will be edited to whichever room the item starts in
    //The object needs to have a base authority of whichever room its meant for
    [SerializeField] private float startPlayer = 0f;
    //Player1 = 0
    //Player2 = 1
    //By default this is set to 0
    [SerializeField] private ulong playerId = 0;

    //This variable will track whether the object is transitioning or not, this is to counteract the double transfer bug we've been having
    private bool inTransit = false;

    //Keep checking state of the object
    private bool StartCheck = true; 
    
    // Start is called before the first frame update
    void Start()
    {
        _Network = GetComponent<NetworkObject>();
        //_Network.ChangeOwnership(playerId);

        //Make sure the playerID is associated with the proper player
        //playerId = Convert.ToUInt64(startPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (StartCheck == true)
        {
            _Network.ChangeOwnership(Convert.ToUInt64(startPlayer));
        }*/
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Chute" && inTransit == false)
        {
            StartCheck = false; 
            inTransit = true; 
            Debug.LogError("Chute DETECTED");
            StartCoroutine(waiting());
            
            
        }
    }

    [Rpc(SendTo.Server)]
    public void AuthorityRpc()
    {
        Debug.LogError("Transfer authority . . .");
        //yield return new WaitForSeconds(0.2f);
        if (playerId == 1)
        {
            
            playerId = 0;
            //_Network.IsOwnedByServer.Equals(true);
            _Network.ChangeOwnership(0);
            playerId = 0;
            
        }
        else
        {
            playerId = 1; 
            _Network.ChangeOwnership(1); 
            playerId = 1;
        }
        //networkLoad();
        
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(2f);
        inTransit = false;
        AuthorityRpc();
    }
    
    /*
    
    //This method can be called by either client and will be sent to the server side 
    //This method then needs to differentiate between which player is grabbing the object
    //and set that to the owner 
    [Rpc(SendTo.Me)] 
    public void messageRpc()
    {
        messageLogRpc();
        
        
        if (!IsOwner)
        {
            serverOverideRpc();
        }
        else
        {
            Debug.Log("You own the gameobject");
            //Debug.Log("We are gonna change that");
             //_Network.ChangeOwnership(1);
        }
    }

    [Rpc(SendTo.Server)]
    private void messageLogRpc()
    {
        Debug.Log("Rpc called in some way");
    }
    
    [Rpc(SendTo.Server)]
    public void serverOverideRpc()
    {
        Debug.Log("This is not the owner of the object, lets change that");
        if (playerId == 1)
        {
            playerId = 0;
            _Network.ChangeOwnership(playerId);
        }
        else
        { 
            playerId = 1;
            _Network.ChangeOwnership(playerId);
        }
        Debug.Log("Server changed object authority");
        
    } */
   
    /*
    public void Authorize()
    {
        Debug.Log("Authorize has been called");
        _Network.ChangeOwnership(newOwnerID);
        Debug.Log("Ownership changed to " + newOwnerID);
       messageRpc();
    }*/
    
}
