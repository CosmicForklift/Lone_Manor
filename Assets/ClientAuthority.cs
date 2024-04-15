using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.XR.Interaction.Toolkit;

public class ClientAuthority : MonoBehaviour
{
    private XRGrabInteractable _interactor = null;
    public bool IsGrabbed;

    private void Awake()
    {
        _interactor = GetComponent<XRGrabInteractable>();
        IsGrabbed = false;
    }

    public void grabbed()
    {
        
    }
}
