using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera : MonoBehaviour
{
    public cube cube;
    public Transform karakter,kamera,target;
    public float upCount=7, forwardCount=-3.5f;
   
    
   
   
    
  
    void Start()
    {
        
    }

    
    void Update()
    {

        
        kamera.LookAt(target);
        kamera.transform.position = Vector3.Lerp(kamera.transform.position, karakter.transform.position + -karakter.transform.forward * forwardCount + Vector3.up * upCount,8*Time.deltaTime);
        
        

        
        //kamera.transform.position = karakter.transform.position + -karakter.transform.forward*13+Vector3.up*7;
       
        

    }

   

        
}
