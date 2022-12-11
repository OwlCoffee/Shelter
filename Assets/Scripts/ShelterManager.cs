using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterManager : MonoBehaviour
{
    public Shelter shelter;

    private Vector3 startPosition = new Vector3(0.0f, -0.7f, 0.0f);

    private void Awake()
    {
        Shelter startShelter = Instantiate(shelter, startPosition, Quaternion.Euler(Vector3.zero));

        startShelter.SetShelterTag("StartShelter");

        Vector3 randomPosition = new Vector3(Random.Range(10, 80), -0.7f, Random.Range(10, 80));
        Vector3 rotation = Vector3.zero;
        Shelter goalShelter = Instantiate(shelter, randomPosition, Quaternion.Euler(rotation));

        goalShelter.SetShelterTag("GoalShelter");
    }
}
