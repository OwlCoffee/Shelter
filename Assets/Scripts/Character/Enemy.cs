using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Life
{
    NavMeshAgent tracePlayer;
    Transform target;

    private float enemyMaxHealth;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        enemyMaxHealth = 30.0f;
        SetMaxHealth(enemyMaxHealth);

#if UNITY_EDITOR
        Debug.Log("Enemy's Max health " + maxHealth);
#endif

        tracePlayer = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
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

                if (targetDistance < 3.0f) tracePlayer.Stop();
                else tracePlayer.Resume();

//#if UNITY_EDITOR
//                Debug.Log(targetDistance);
//#endif
            }

            yield return new WaitForSeconds(traceRate);
        }
    }

    protected float CalculateDistance(Vector3 target)
    {
        float distance;

        float xDifferent = target.x - transform.position.x;
        float zDifferent = target.z - transform.position.z;

        distance = Mathf.Sqrt(xDifferent * xDifferent + zDifferent * zDifferent);

        return distance;
    }
}
