using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    [SerializeField] float openRange = 5f;
    [SerializeField] Animator anim;
    [SerializeField] Transform Player;
    [SerializeField] Transform door;
    [SerializeField] AudioSource audioSource;

    private void Update()
    {
        float Distance = Vector3.Distance(Player.transform.position, door.transform.position);
        if (Distance <= openRange)
        {

            anim . SetBool("Near",true);
           
        }
        else
        {
            anim.SetBool("Near", false);
             
        }
    }
}
   
    
 

        