using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SafeNumManager : MonoBehaviour
{
    public TMP_Text canvasText;

    public Button countUp; 
    
    public float numDisplay = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        canvasText.text = "" + numDisplay;
       // Debug.Log(canvasText.text);
    }

    
    
    // Update is called once per frame
    void Update()
    {
      
    }
}
