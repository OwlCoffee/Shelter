using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour, IDamageable
{
    protected float maxHealth;
    protected float health;

    protected bool isDead;

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
        DataManager.Instance().Scoring();
        Destroy(gameObject);
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
}
