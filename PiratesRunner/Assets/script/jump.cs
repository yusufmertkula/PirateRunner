using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    AudioSource audioSource;
    public cube cube;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (cube.jump)
        {
            audioSource.Play();
        }    
    }
}
