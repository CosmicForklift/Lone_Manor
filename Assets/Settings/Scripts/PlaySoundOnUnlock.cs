using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnUnlock : MonoBehaviour
{
    AudioSource source;
    Collider soundTrigger;
    // Start is called before the first frame update

    private void Awake()
    {
       source = GetComponent<AudioSource>();
       soundTrigger = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Key")
        {
            source.Play();
            Destroy(source, 3);
        }
    }
}
