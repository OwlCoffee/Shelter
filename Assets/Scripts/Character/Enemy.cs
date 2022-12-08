using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Life
{
    NavMeshAgent tracePlayer;
    Transform target;
    GameObject player;

    private Animator enemyAnimator;

    private float enemyMaxHealth;
    private bool state_Attack;
    private float damage;

    private void Update()
    {
        enemyAnimator.SetBool("HasTarget", target);

        if (isDead) enemyAnimator.SetTrigger("Die");
    }
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        enemyMaxHealth = 30.0f;
        SetMaxHealth(enemyMaxHealth);
        state_Attack = false;
        damage = 10.0f;

#if UNITY_EDITOR
        Debug.Log("Enemy's Max health " + maxHealth);
#endif

        tracePlayer = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;

        // Enemy Animation
        enemyAnimator = GetComponent<Animator>();

        StartCoroutine(UpdatePath());
        StartCoroutine(AttackLoop());
    }

    IEnumerator UpdatePath()
    {
        float traceRate = 0.1f;
        float targetDistance;

        while (target != null)
        {
            if (!isDead)
            {
                Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
                targetDistance = CalculateDistance(targetPosition);

                tracePlayer.SetDestination(targetPosition);

                if (targetDistance < 3.0f)
                {
                    tracePlayer.Stop();
                    state_Attack = true;
                }
                else
                {
                    tracePlayer.Resume();
                    state_Attack = false;
                }

                //#if UNITY_EDITOR
                //                Debug.Log(targetDistance);
                //#endif
            }

            yield return new WaitForSeconds(traceRate);
        }
    }

    IEnumerator AttackLoop()
    {
        float attackRate = 1.0f;

        while (target != null)
        {
            if (!isDead)
            {
                if (state_Attack)
                {
                    Debug.Log("Attack");
                    Attack(player);
                }
            }

            yield return new WaitForSeconds(attackRate);
        }
    }

    public void Attack(GameObject hit)
    {
        IDamageable damageable = hit.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }

#if UNITY_EDITOR
        Debug.Log("Hit");
#endif
    }

    protected float CalculateDistance(Vector3 target)
    {
        float distance;

        float xDifferent = target.x - transform.position.x;
        float zDifferent = target.z - transform.position.z;

        distance = Mathf.Sqrt(xDifferent * xDifferent + zDifferent * zDifferent);

        return distance;
    }

    public void SetSpeed(float speed)
    {
        tracePlayer.speed = speed;
    }
}
