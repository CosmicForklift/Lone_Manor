using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BookCheck : MonoBehaviour
{
    //This script will illuminate the tiles beneath when the corresponding book is attached to it
    
    //Corresponding book
    [SerializeField] private GameObject _book;
    [SerializeField] private GameObject _box;

    private colorController _colorController;

    private void Awake()
    {
        
        //_box = GetComponentInChildren<GameObject>();
        _colorController = GetComponentInChildren<colorController>();

    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.GameObject() == _book.GameObject())
        {
            
            _colorController.colorChangeGreen();
            
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GameObject() == _book.GameObject())
        {
            
            _colorController.colorChangeRed();
            
        }
        
    }
}
