using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    private bool pressed = false;

    public GameObject pivotObject;

    public GameObject doorObject;
    
    private float rotationSpeed = 0f; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        doorObject.transform.RotateAround(pivotObject.transform.position, new Vector3(0, -1, 0), rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("It worked less!!!!!");
        buttonPressed();
        if (other.CompareTag("Player"))
        {
            Debug.Log("It worked!!!!!");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
       buttonPressed();
    }

    private void buttonPressed()
    {
         if (pressed == false)
                {
                    pressed = true;
                    transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
                    StartCoroutine(Open());
                    Debug.Log("Button has been pressed");
                    
                    
                    
                }
    }
    
    private IEnumerator Open()
    {
        rotationSpeed = 180f;
        yield return new WaitForSeconds(0.5f);
        rotationSpeed = 0f;
    }
}
