using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DoorScript : MonoBehaviour
{
    private Vector3 shift;

    public GameObject pivotObject;
    // Start is called before the first frame update
    void Start()
    {
        //_axisObject = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Key")
        {
            Debug.Log("Key detected");
            transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
          // transform.RotateAround(pivotObject.transform.position, Vector3.up, 20 * Time.deltaTime); 
           //Destroy(other);
        }

            
        throw new NotImplementedException();
    }
}
