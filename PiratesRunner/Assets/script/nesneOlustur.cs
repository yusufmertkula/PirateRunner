using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class nesneOlustur : MonoBehaviour
{
    public GameObject chest,skull,barrel,yol,nesneDuvar,carpma,GameOver,AudioSkull;
    float a = -50, b = 0;
    int c = 0, sayac, nesneSecimi, skor = 0;
    public int carpti=0;
    public Text text,score;
    public cube cube;
    public Animator animation;
    public bool gameOver=false;
    Object [] yeniNesne = new Object [27];
    public camera camera;
    void Start()
    {
        animation = GetComponent<Animator>();
       
    }


    void Update()
    {
        

    }
    private void OnTriggerEnter(Collider other)
    {
               
        if (other.CompareTag("nesneOlusturDuvar"))
        {
            b = -3;       
            c = 0;
            GameObject yeniYol = new GameObject();
            yeniYol.transform.position = new Vector3(nesneDuvar.transform.position.x , 2, nesneDuvar.transform.position.z);
            do
            {
              
                do
                {

                    nesneSecimi = Random.Range(0, 3);

                    if (nesneSecimi == 0)
                    {

                        yeniNesne[c] = Instantiate(chest, yeniYol.transform.position + nesneDuvar.transform.forward * a + nesneDuvar.transform.right * b, chest.transform.rotation);

                    }

                    if (nesneSecimi == 1)
                    {

                        
                        yeniNesne[c] = Instantiate(skull, yeniYol.transform.position + nesneDuvar.transform.forward * a + nesneDuvar.transform.right * b, skull.transform.rotation);

                    }
                    if (nesneSecimi == 2)
                    {

                        
                        yeniNesne[c] = Instantiate(barrel, yeniYol.transform.position + nesneDuvar.transform.forward * a + nesneDuvar.transform.right * b+nesneDuvar.transform.up*-1.5f, barrel.transform.rotation);

                    }

                    a = a + 14;
                    c++;
                    sayac++;

                } while (sayac < 9);

                sayac = 0;
                a = -50;
                b = b + 3; ;
                Destroy(yeniYol);
            }while (b<4);
            
        }

        if (other.CompareTag("duvar"))
        {
           
            for (int i = 0; i < 27; i++)
            {
            
                Destroy(yeniNesne[i]);
                
            }

        }

        

        if (other.CompareTag("barrel"))
        {
            gameOver = true;
            GetComponent<AudioSource>().enabled = false;

            camera.forwardCount = -3.5f;
           
            animation.SetTrigger("death");

            GameOver.SetActive(true);
            
            cube.hiz = 0;
        }

    }
   
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("chest"))
        {

            


            Destroy(other.gameObject);
            skor = skor + 10;
            score.text = skor.ToString();


        }

        if (other.CompareTag("skull"))
        {

            Destroy(other.gameObject);
            skor = skor - 10;
            score.text = skor.ToString();

        }
    }
} 
