using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class WapenScrpt : MonoBehaviour
{
    public Camera FPCamera;
    public  float RayRange = 100f;
    public float damage = 30f;
    [SerializeField] ParticleSystem muzzleFX;
    [SerializeField] GameObject hiteffect;
    [SerializeField] GameObject WallHiteffect;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo AmmoSlot;
    [SerializeField] Text ammoText;
    [SerializeField] AudioSource gubShot;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    
    void Update()
    {
         DisplayAmmo();
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    private void DisplayAmmo()
    {
        float currentAmmo = AmmoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }
    private void Shoot()
    {
        if (AmmoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            muzzleFlash();
            processRayCast();
            AmmoSlot.reduceCurrentAmmo(ammoType);
            gubShot.Play();
        }
        
    }

    private void muzzleFlash()
    {
        muzzleFX.Play();
        

    }
    private void processRayCast()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, RayRange))
        {

            createHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                GameObject WallImpact = Instantiate(WallHiteffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(WallImpact, 5);
                return;
            }
            target.TakeDamage(damage);
           
          
        }
        else
        {
            return;
        }
       
    }

    private void createHitImpact(RaycastHit hit)
    {
         GameObject impact =   Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
         Destroy(impact, 2);
    }
}
  