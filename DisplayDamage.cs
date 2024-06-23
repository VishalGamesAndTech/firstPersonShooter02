using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{

    [SerializeField] Canvas BloodSplatter;
    [SerializeField] float impactTime = 0.3f;
  
   
   
    void Start()
    {
        BloodSplatter.enabled = false;
    }

  

    public void showDamage()
    {
        StartCoroutine(showSplatter());
    }

    IEnumerator showSplatter()
    {
        BloodSplatter.enabled = true;
        yield return new WaitForSeconds(impactTime);
        BloodSplatter.enabled = false;
    }

   
    
}
