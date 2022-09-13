using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public bool onTheGround = false;
   public bool jump = false;
    float sayac;
   public bool doubleJump = true;
    public GameObject yol1;
    public GameObject yol2;
   public float donus = 2;

    public int yolsecimi;
    public GameObject karakter;
   public float donusSayac=1;
    int kontrol=1;
    public bool donusIzni=true;
    public bool solaGec = false;
    public bool sagaGec=false;
    bool donusKontrol = false;
    public Animator animation;
    public float hiz=10f;
    public GameObject gameover;
    public AudioSource audioSource;
    public  nesneOlustur nesneOlustur;
    void Start()
    {
        animation = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }


    void Update()
    {

        
        transform.position = transform.position + transform.forward * hiz * Time.deltaTime;

        if (!onTheGround)
        {
            if (nesneOlustur.carpti == 0)
            {
                audioSource.Play();
            }

        }

        if (SwipeInput.swipedLeft && kontrol != 0 && donusIzni && !solaGec && !sagaGec && !nesneOlustur.gameOver)
        {
            solaGec = true;
            donus = 0;
            kontrol -= 1;

        }
        if (solaGec)
        {

            transform.position = Vector3.Lerp(transform.position, transform.position - transform.right*0.6f, 10 * Time.deltaTime);
            donus = donus + Time.deltaTime;
            if (donus >= 0.5f)
            {
                solaGec = false;
            }

        }



        if (SwipeInput.swipedRight && kontrol != 2 && donusIzni && !solaGec && !sagaGec &&!nesneOlustur.gameOver)
        {
            sagaGec = true;
            donus = 0;
            kontrol += 1;

        }
        if (sagaGec)
        {

            transform.position = Vector3.Lerp(transform.position, transform.position + transform.right * 0.6f, 10 * Time.deltaTime);
            donus = donus + Time.deltaTime;
            if (donus >= 0.5f)
            {
                sagaGec = false;
            }
        }

        if (SwipeInput.swipedUp && onTheGround&& !nesneOlustur.gameOver)
        {
            animation.SetTrigger("jump");
            jump = true;
            sayac = 0;

        }

        if (SwipeInput.swipedUp && !onTheGround && doubleJump)
        {
            animation.SetTrigger("jump");
            doubleJump = false;
            jump = true;
            sayac = 0;

        }

        if (jump)

        {


            

            sayac += 1 * Time.deltaTime;
            transform.Translate(0, 11 * Time.deltaTime, 0);

            if (sayac >= 0.4f)
            {

                jump = false;

            }

        }





        if (!onTheGround && !jump)
        {

            transform.Translate(0, -11 * Time.deltaTime, 0);

        }

        if (donusSayac < 1)
        {

            karakter.transform.rotation = Quaternion.Lerp(transform.rotation, yol2.transform.rotation, 7*Time.deltaTime);
            

            
            donusSayac = donusSayac + Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("solDuvar") && yolsecimi == 0)
        {

            donusSayac = 0;
            

        }

        if (other.CompareTag("sagDuvar") && yolsecimi == 1)
        {

            donusSayac = 0;

        }

        if (other.CompareTag("duvar2"))
        {

            donusSayac = 0;

        }

        if (other.CompareTag("duvar"))
        {

            donusIzni = false;

        }

        


    }
    private void OnTriggerStay(Collider other)
    {
        
        

        if (other.CompareTag("zemin"))
        {
            
            onTheGround = true;
            doubleJump = true;
            sayac = 0;
            

        }
        
    }
    public void OnTriggerExit(Collider other)
    {
    
        if (other.CompareTag("duvar"))
        {
        
            donusIzni = true;

        }

        if (other.CompareTag("zemin"))
        {

            onTheGround = false;

        }

        if (other.CompareTag("yolOlusturDuvar"))
        {

            yolsecimi = Random.Range(0, 2);

            if (yolsecimi == 0)
            {

                yol2.transform.Translate(-75.5f, 0, 84.5f);
                yol2.transform.Rotate(0, 270, 0);
                 

            }
 
            if (yolsecimi == 1)
            {
               
                yol2.transform.Translate(75.5f, 0, 84.5f);
                yol2.transform.Rotate(0, 90, 0);
            
            }


        }

        if (other.CompareTag("duvar"))
        {


            
           

            if (yolsecimi == 0)
            {
                yol1.transform.Translate(-75.5f, 0, 84.5f);
                yol1.transform.Rotate(0, 270, 0);
            }
            if (yolsecimi == 1)
            {
                yol1.transform.Translate(75.5f, 0, 84.5f);
                yol1.transform.Rotate(0, 90, 0);
            }
        }
        




        




    }
}


