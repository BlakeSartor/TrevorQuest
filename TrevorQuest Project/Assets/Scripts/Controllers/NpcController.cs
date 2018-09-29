using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour {

    public float aggroRange = 10f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

	// Use this for initialization
	void Start () {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();

	}
	
	// Update is called once per frame
	void Update () {

        float distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= aggroRange)
        {
            agent.SetDestination(target.position);

            if (distanceToTarget <= agent.stoppingDistance)
            {
                // ATTACKK!!
                CharStats targetStats = target.GetComponent<CharStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }
                
                // Rotate to face target!?
                FaceTarget();

            }
        }	
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
