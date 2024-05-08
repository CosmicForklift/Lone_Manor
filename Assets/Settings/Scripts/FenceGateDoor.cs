using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FenceGateDoor : MonoBehaviour
{
    public GameObject _key;

    public GameObject _doorLeft;

    public GameObject _doorRight;

    public GameObject _axisLeft;

    public GameObject _axisRight;

    public AudioSource source;

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
    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Key detected");
        
        if (doorOpen == false && other.GameObject() == _key.GameObject())
        {
            doorOpen = true;
            StartCoroutine(Open());
            Destroy(this._key);
            transform.position = Vector3.down;
        }
    }
 
    private IEnumerator Open()
    {
        source.Play();
        rotationSpeed = 90f;
        yield return new WaitForSeconds(1f);
        rotationSpeed = 0f;
        Destroy(gameObject);
        Destroy(source,3);
    }
    
}
