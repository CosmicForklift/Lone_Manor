using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] AudioSource source1;
    [SerializeField] AudioSource source2;
    [SerializeField] AudioSource source3;
    Collider soundTrigger;

    // Start is called before the first frame update

    private void Awake()
    {
        source1 = GetComponent<AudioSource>();
        source2 = GetComponent<AudioSource>();
        source3 = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider>();
    }

    private void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Grass")
        {
            source1.Play();
        }

        if (collider.gameObject.tag == "Gravel")
        {
            source2.Play();
        }

        if (collider.gameObject.tag == "Grass")
        {
            source3.Play();
        }
    }
}
