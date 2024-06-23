using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] AmmoSlot[] ammoSlot;



    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int AmmoAmount;
    }

    public float GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).AmmoAmount;
    }
    public void reduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).AmmoAmount--;
    }
    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).AmmoAmount += ammoAmount;
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot Slot in ammoSlot)
        {
            if(Slot.ammoType == ammoType)
            {
                return Slot;
            }

        }
        return null;
    }
}
    