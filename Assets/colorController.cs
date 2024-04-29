using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorController : MonoBehaviour
{
    
    private Renderer boxRenderer; 
    
    // Start is called before the first frame update
    void Start()
    {
        boxRenderer = GetComponent<Renderer>();
        boxRenderer.material.color = Color.red;
    }

    public void colorChangeGreen()
    {
        boxRenderer.material.color = Color.green;
    }

    public void colorChangeRed()
    {
        boxRenderer.material.color = Color.red;
    }
}
