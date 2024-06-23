using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikupAmmoScript : MonoBehaviour
{
    //public Camera FPCamera;
    //public float RayRange = 10f;
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioSource ammoSource;
    [SerializeField] AudioClip ammoClip;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
            //AudioSource.PlayClipAtPoint(ammoClip, Camera.main.transform.position, 0.5f);
            ammoSource.Play();
        }
    }

    
}
