using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceGateDoor : MonoBehaviour
{
    public GameObject _key;

    public GameObject _doorLeft;

    public GameObject _doorRight;

    public GameObject _axisLeft;

    public GameObject _axisRight;

    private bool doorOpen = false;

    private float rotationSpeed = 0f;
        
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _doorLeft.transform.RotateAround(_axisLeft.transform.position, new Vector3(0, -1, 0), rotationSpeed * Time.deltaTime);
        _doorRight.transform.RotateAround(_axisRight.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
    }
    
    private void OnCollisionEnter(Collision _key)
    {
        Debug.Log("Key detected");
        
        if (doorOpen == false)
        {
            doorOpen = true;
            StartCoroutine(Open());
            Destroy(this._key);
            transform.position = Vector3.down;
        }
    }
 
    private IEnumerator Open()
    {
        rotationSpeed = 90f;
        yield return new WaitForSeconds(1f);
        rotationSpeed = 0f;
        Destroy(gameObject);
    }
    
}
