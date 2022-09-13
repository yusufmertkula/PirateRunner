using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    int kontrol=1;
    bool solaGec=false;
    bool sagaGec=false;
    float donus = 0;
    public Animator animation;
    bool doubleJump = true;
    bool jump = false;
    float sayac;
    cube cube;
   
    
    void Start()
    {
        animation = GetComponent<Animator>();
    }

   
    void Update()
    {
        transform.position = transform.position + transform.forward * 0.1f;


        if (Input.GetKeyDown(KeyCode.A) && kontrol != 0 && cube.donusIzni && !solaGec && !sagaGec)
        {
            solaGec = true;
            donus = 0;
            kontrol -= 1;

        }
        if (solaGec)
        {

            transform.position = Vector3.Lerp(transform.position, transform.position + -transform.right * 0.6f, 10 * Time.deltaTime);
            donus = donus + Time.deltaTime;
            if (donus >= 0.5f)
            {
                solaGec = false;
            }

        }



        if (Input.GetKeyDown(KeyCode.D) && kontrol != 2 && cube.donusIzni && !solaGec && !sagaGec)
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

        if (Input.GetKeyDown(KeyCode.Space) && cube.onTheGround)
        {
            animation.SetTrigger("jump");
            jump = true;
            sayac = 0;

        }

        if (Input.GetKeyDown(KeyCode.Space) && !cube.onTheGround && doubleJump)
        {

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





        if (!cube.onTheGround && !jump)
        {

            transform.Translate(0, -11 * Time.deltaTime, 0);

        }
    }
}
