using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float hitPoins = 10f;
    [SerializeField] public int hasKey = 0;
    float barFillAmount = 1f;
    [SerializeField] float Damage = 0;
    public PlayerHealthBarScript PlayerHealthBar;
    [SerializeField] GameObject KeyImage;
    [SerializeField] AudioSource audioSource;
    public Image healthBar;
    [SerializeField] AudioClip healthPickupSound;
    float MaxHealth = 10;




    // Start is called before the first frame update
    void Start()
    {
        Damage = barFillAmount / hitPoins;
        KeyImage.SetActive(false);
    }

   

    public void PlayerTakeDamage()
    {

        DamagePlayerHealthBar();

        if (hitPoins <= 0)
        {
           
            GetComponent<DeathHandler>().HandleDeath();
            
        }
    }
    void DamagePlayerHealthBar()
    {
        if (hitPoins > 0)
        {
            hitPoins -= 1f;
            barFillAmount = barFillAmount - Damage;
            PlayerHealthBar.setAmount(barFillAmount);
            
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            hasKey += 1;
            Destroy(other.gameObject);
            KeyImage.SetActive(true);
            audioSource.Play();
        }
        if (other.gameObject.tag == "Health")
        {
            audioSource.PlayOneShot(healthPickupSound, 1f);
            Destroy(other.gameObject);
           
            if (hitPoins < MaxHealth)
            {
                hitPoins += 2f;
                healthBar.fillAmount += 0.1f;
            }
            else
            {
                return;
            }
        }
    }
   

  


}
