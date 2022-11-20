using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask collisionMask;

    private float speed = 0.0f;
    private float damage = 10.0f;

    private void Start()
    {
        Destroy(gameObject, 2.0f); // Destory 2 sec later
    }

    void Update()
    {
        float distance = speed * Time.deltaTime;
        CheckCollision(distance);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void SetProjectileSpeed(float value)
    {
        speed = value;
    }

    public void CheckCollision(float distance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHit(hit);
        }
    }

    public void OnHit(RaycastHit hit)
    {
        IDamageable damageable = hit.collider.GetComponent<IDamageable>();

        if(damageable!=null)
        {
            damageable.TakeDamage(damage, hit);
        }

#if UNITY_EDITOR
        Debug.Log("Hit");
#endif

        GameObject.Destroy(gameObject);
    }
}
