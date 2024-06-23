using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth Target;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip DamageSound;
    
    // Start is called before the first frame update
    void Start()
    {
        Target = FindObjectOfType<PlayerHealth>();
    }
    public void OnDamageTaken()
    {
       
    }

    private void AttackHitEvent()
    {
        if (Target == null)  return;
        Target.PlayerTakeDamage();
        Target.GetComponent<DisplayDamage>().showDamage();
        audioSource.PlayOneShot(DamageSound, 1f);
    }
}
