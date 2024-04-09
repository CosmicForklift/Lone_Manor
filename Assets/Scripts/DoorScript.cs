using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DoorScript : MonoBehaviour
{
    private float rotationSpeed = 0f;

    public GameObject pivotObject;

    public GameObject _key;

    public GameObject _door; 

    private bool doorOpen = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        //_axisObject = GetComponent<Transform>();
        Debug.Log("The key's ID is " + _key.GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {
        _door.transform.RotateAround(pivotObject.transform.position, new Vector3(0, -1, 0), rotationSpeed * Time.deltaTime);

        if (transform.rotation.y <= -90)
        {
            rotationSpeed = 0f; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("THe ID of other is " + other.GetInstanceID());
       // if (other.CompareTag("Key"))
            if (other.GameObject() == _key.GameObject())
        {
            
                Debug.Log("The ID's are the same");
                
                if (doorOpen == false)
                {
                                                        
                                Debug.Log("Key detected");
                                doorOpen = true;
                                StartCoroutine(Open());
                                Destroy(_key);
                }
            
        } 
    }

    /*
                */
    
    private IEnumerator Open()
    {
        rotationSpeed = 180f;
        yield return new WaitForSeconds(0.5f);
        rotationSpeed = 0f;
    }
    
}
