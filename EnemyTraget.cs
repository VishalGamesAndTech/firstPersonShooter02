using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTraget : MonoBehaviour
{
    public Transform Target;
    public float chaseRange = 10f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] AudioSource EnemyAwak;
    [SerializeField] AudioSource zombiVoice;

    NavMeshAgent NavMeshAgent;
    float distanceToTarget;
    public bool isProvoked = false;
     EnemyHealth Halth;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        Halth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
       
        distanceToTarget = Vector3.Distance(Target.position,transform.position);
        if (isProvoked)
        {
            EngageTarget();
           
        }
         else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            EnemyAwak.Play();

        }
        if (Halth.IsDead())
        {
            enabled = false;
            NavMeshAgent.enabled = false;
            EnemyAwak.Stop();
            zombiVoice.Stop();

        }

    }
    public void OnDamageTaken()
    {
        isProvoked = true;
        zombiVoice.Play();
    }
        
    private void EngageTarget() 
    {
        FaceTarget();
        if (distanceToTarget >= NavMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

         if (distanceToTarget <= NavMeshAgent.stoppingDistance)
        {
            AttackTarget();
            
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack",true);
       
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        NavMeshAgent.SetDestination(Target.position);
        
    }

    private void FaceTarget()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation( new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime* turnSpeed);

    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
