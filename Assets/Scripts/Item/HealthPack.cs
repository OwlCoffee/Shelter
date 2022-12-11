using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour, IItem
{
    public float health = 30.0f;

    public void Use(GameObject target)
    {
        Character player = target.GetComponent<Character>();

        if (player != null)
        {
            player.RestoreHealth(health);
        }

        Destroy(gameObject);
    }
}