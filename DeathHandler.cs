using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;
    [SerializeField] Canvas GunRaticlCanvas;
    
    



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        GunRaticlCanvas.enabled = true;
        GameOverCanvas.enabled = false;
       
       

    }
    public void HandleDeath()
    {
        
        GameOverCanvas.enabled = true;
        GunRaticlCanvas.enabled = false;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwich>().enabled = false;
        FindObjectOfType<FirstPersonController>().enabled = false;
        FindObjectOfType<WapenScrpt>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
    }


}
