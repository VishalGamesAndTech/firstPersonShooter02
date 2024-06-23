using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor02 : MonoBehaviour
{
  

   
    [SerializeField] float openRange = 5f;
    [SerializeField] Animator anim;
    [SerializeField] Transform Player;
    [SerializeField] Transform door;
    [SerializeField] Text PressE02;
    [SerializeField] AudioSource audioSource;
    


    private void Start()
    {
        PressE02.enabled = false;
        
    }
    private void Update()
    {
        float Distance = Vector3.Distance(Player.transform.position, door.transform.position);
        if (Distance <= openRange)
        {
            PressE02.enabled = true;
        }
         if (Input.GetKey(KeyCode.E))
        {
            if (Distance <= openRange)
            {
                audioSource.Play();

                anim.SetBool("Near", true);
            }
            if (Distance >= openRange)
            {
                anim.SetBool("Near", false);
                audioSource.Play();
               


            }


        }
        if (Distance >= openRange)
        {
           
            

            PressE02.enabled=false;
            

        }
       
        

        

    }
}
