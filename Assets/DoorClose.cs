using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
		
	//private collider closeCollider;
	public bool doorOpen;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        
		if(collider.gameObject.tag == "Player" && doorOpen == true)
		{
			
		StartCoroutine(Close());
		doorOpen = false;
		Destroy(this);
		}
		
    }
	
	private IEnumerator Close()
    {
        //rotationSpeed = -180f;
        yield return new WaitForSeconds(0.5f);
        //rotationSpeed = 0f;
    }
}
