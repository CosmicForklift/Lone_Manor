using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarredWoodenDoor : MonoBehaviour
{
    //The door will check for the existence of the three wooden bars
    //Each wooden bar has a script to check if it hit with an axe, and if done so will be destroyed

    private float rotationSpeed = 0f; 
    
    public GameObject _woodenBar1;
  
    public GameObject _woodenBar2;

    public GameObject _woodenBar3;
    
    public GameObject pivotObject;
    
    //public GameObject _door;

    public float count = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, -1, 0), rotationSpeed * Time.deltaTime);
        
        //Check to see if the wooden bar does exist and report that to the console 
        if (_woodenBar1 != null && _woodenBar2 != null && _woodenBar3 != null)
        {
            //Debug.Log("The door is barred");
        }
        else
        {
            //Debug.Log("OPEN SESAME");
        }
    }

    public void OpenAttempt()
    {
        if (count == 3)
        {
            StartCoroutine(Open());
        }
    }
    
    private IEnumerator Open()
    {
        rotationSpeed = 180f;
        yield return new WaitForSeconds(0.5f);
        rotationSpeed = 0f;
    }
    
}
