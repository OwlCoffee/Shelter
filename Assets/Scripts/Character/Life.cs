using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour, IDamageable
{
    protected float maxHealth;
    protected float health;

    protected bool isDead;

    public event Action onDeath;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        maxHealth = 100.0f;
        health = maxHealth;

        isDead = false;
    }

    protected void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        health = this.maxHealth;
    }

    protected void Die()
    {
        isDead = true;
        
        if (gameObject.tag.Equals("Enemy"))
        {
            if (onDeath != null)
            {
                onDeath();
            }

            DataManager.Instance.Scoring();
        }
        else if (gameObject.tag.Equals("Player")) Debug.Log("Player is dead");
    }

    public void TakeDamage(float damage, RaycastHit ray)
    {
        health -= damage;

#if UNITY_EDITOR
        Debug.Log("Object's hp " + health);
#endif

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

#if UNITY_EDITOR
        Debug.Log("Object's hp " + health);
#endif

        if (health <= 0 && !isDead)
        {
            Die();
            SceneLoader.Instance.LoadGameOverScene();
        }
    }
}
