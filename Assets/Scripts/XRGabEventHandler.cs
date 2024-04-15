using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGabEventHandler : MonoBehaviour
{
    public ulong avatarNetworkObjectID;
    public GameObject avatarObject;

    public void SelectLeftGrabEnterEventController(SelectEnterEventArgs eventArgs)
    {
        var grabbedObj = eventArgs.interactableObject.transform.GetComponent<NetworkObject>();
        //avatarObject.GetComponent<>().AvatarSelectGrabEnterEventHub(grabbedObj, true);
    }
}
