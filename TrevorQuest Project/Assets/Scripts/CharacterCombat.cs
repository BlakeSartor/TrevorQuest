using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharStats))]
public class CharacterCombat : MonoBehaviour {

    public float attackSpeed = 1f;
    public float attackDelay = 0.6f;
    const float combatCoolDown = 5;

    float lastAttackTime;


    private float attackCooldown = 0f;

    public bool InCombat { get; private set; }
    public event System.Action OnAttack;

    CharStats myStats;

    
    void Start()
    {
        myStats = GetComponent<CharStats>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
        //No Longer in Combat. Based on combatCoolDown
        if (Time.time - lastAttackTime > combatCoolDown)
        {
            InCombat = false;
        }


    }

    public void Attack (CharStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
            {
                OnAttack();
            }

            attackCooldown = 1f / attackSpeed;
            InCombat = true;
            lastAttackTime = Time.time;

        }

    }

    IEnumerator DoDamage (CharStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
        if (stats.currentHealth <= 0)
        {
            InCombat = false;
        }
    }
}
