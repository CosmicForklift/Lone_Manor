using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DoorScript : MonoBehaviour
{
    private float rotationSpeed = 0f;

    public GameObject pivotObject;

    private bool doorOpen = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        //_axisObject = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, -1, 0), rotationSpeed * Time.deltaTime);

        if (transform.rotation.y <= -90)
        {
            rotationSpeed = 0f; 
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Key" && doorOpen == false)
        {
            Debug.Log("Key detected");
            doorOpen = true; 
            StartCoroutine(Open());
           //Destroy(other);
        }
    }

    private IEnumerator Open()
    {
        rotationSpeed = 180f;
        yield return new WaitForSeconds(0.5f);
        rotationSpeed = 0f;
    }
    
}
