using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//When all 6 books are found trigger the escape mechanism 

public class EscapeTrigger : MonoBehaviour
{

    [SerializeField] private BookCheck _book1;
    [SerializeField] private BookCheck _book2;
    [SerializeField] private BookCheck _book3;
    [SerializeField] private BookCheck _book4;
    [SerializeField] private BookCheck _book5;
    [SerializeField] private BookCheck _book6;

    private GameObject _player; 
    
    public GameObject _door1;

    public GameObject _pivotPoint1;
    
    public GameObject _door2;

    public GameObject _pivotPoint2;

    private float rotationSpeed = 0f;


    private bool doorOpen = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _door1.transform.RotateAround(_pivotPoint1.transform.position, new Vector3(0, -1, 0), rotationSpeed * Time.deltaTime);
        
        _door2.transform.RotateAround(_pivotPoint2.transform.position, new Vector3(0, -1, 0), rotationSpeed * Time.deltaTime);
        
        if (_book1.bookCheck & _book2.bookCheck & _book3.bookCheck & _book4.bookCheck & _book5.bookCheck & _book6.bookCheck & !doorOpen)
        {
            StartCoroutine(Open());
        }
    }
    
    private IEnumerator Open()
    {
        rotationSpeed = 180f;
        yield return new WaitForSeconds(0.5f);
        rotationSpeed = 0f;
        doorOpen = false; 
    }

    public void EscapeManor()
    {
        _player = GameObject.Find("Player");
        _player.transform.position = new Vector3(-130, 9, -3);
    }
    
    
}
