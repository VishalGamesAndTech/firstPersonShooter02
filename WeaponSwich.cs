using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwich : MonoBehaviour
{
    [SerializeField] int currentWeapons = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetWeponActive();
    }

    void Update()
    {
       
        int previousWeapon = currentWeapons;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapons)
        {

            SetWeponActive();
        }
    }

    private void ProcessScrollWheel()
    {
       if (Input.GetAxis("Mouse ScrollWheel")> 0f)
        {
            if(currentWeapons >= transform.childCount - 1)
            {
                currentWeapons = 0;
            }
            else
            {
                currentWeapons++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWeapons <= 0)
            {
                currentWeapons = transform.childCount - 1;
            }
            else
            {
                currentWeapons--;
            }
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            currentWeapons = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            currentWeapons = 1;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            currentWeapons = 2;
        }
    }

    private void SetWeponActive()   
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapons)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

}
