using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{

    [SerializeField] ContinuousMoveProviderBase movementReference;
    
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleSprint(InputAction.CallbackContext context) 
    {
        if (context.performed) 
        {
            movementReference.moveSpeed *= 2;
        }
    }
}
