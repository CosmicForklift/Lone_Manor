using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeTheManor : MonoBehaviour
{
    private GameObject _player; 
    
    public void EscapeManor()
    {
        _player = GameObject.Find("Player");
        _player.transform.position = new Vector3(-130, 9, -3);
    }
}
