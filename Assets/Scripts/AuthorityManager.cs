using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class AuthorityManager : NetworkBehaviour
{
    //This method needs to check if the player is authorized to use the object
    //If they do not have authority they need to transfer over authority to them 

    private NetworkObject _Network;

    private ulong newOwnerID = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        _Network = GetComponent<NetworkObject>();
        Debug.Log(_Network.NetworkObjectId);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            Debug.Log("This is the owner");
        }
    }

    
    //This method can be called by either client and will be sent to the server side 
    //This method then needs to differentiate between which player is grabbing the object
    //and set that to the owner 
    [Rpc(SendTo.Server)] 
    public void messageRpc()
    {
        Debug.Log("RPC");
    }
    
   
    
    public void Authorize()
    {
        Debug.Log("Authorize has been called");
        _Network.ChangeOwnership(newOwnerID);
        Debug.Log("Ownership changed to " + newOwnerID);
       messageRpc();
    }
    
}
