using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuteScript : MonoBehaviour
{
    //This script will transport items to another location when it is interacted with

    public GameObject _chuteDeposit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        other.transform.position = _chuteDeposit.transform.position;
        other.rigidbody.velocity = new Vector3(0, 0, 0);
    }
}
