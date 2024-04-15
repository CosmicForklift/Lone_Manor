using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class AuthorityManager : NetworkBehaviour
{
    //This method needs to check if the player is authorized to use the object
    //If they do not have authority they need to transfer over authority to them 

    private NetworkObject _Network;

    
    //Player1 = 0
    //Player2 = 1
    private ulong playerId = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        _Network = GetComponent<NetworkObject>();
        _Network.ChangeOwnership(playerId);
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
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
        
    }
   
    /*
    public void Authorize()
    {
        Debug.Log("Authorize has been called");
        _Network.ChangeOwnership(newOwnerID);
        Debug.Log("Ownership changed to " + newOwnerID);
       messageRpc();
    }*/
    
}
