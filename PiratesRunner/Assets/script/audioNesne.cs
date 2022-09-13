using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioNesne : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("karakter"))
        {

            audioSource.Play();
        }
    }
}
