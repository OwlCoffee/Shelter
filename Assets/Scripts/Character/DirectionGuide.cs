using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionGuide : MonoBehaviour
{
    private Vector3 shelterDirection;
    private Vector3 playerFixedPosition;
    private Vector3 shelterFixedPosition;
    private Shelter goalShelter;
    private Shelter[] shelters;

    // Start is called before the first frame update
    void Start()
    {
        shelterDirection = Vector3.zero;
        playerFixedPosition = Vector3.zero;
        shelterFixedPosition = Vector3.zero;

        shelters = FindObjectsOfType<Shelter>();

        foreach (Shelter s in shelters)
        {
            if (s.GetShelterTag().Equals("GoalShelter")) goalShelter = s;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerFixedPosition.x = transform.position.x;
        playerFixedPosition.z = transform.position.z;
        shelterFixedPosition.x = goalShelter.transform.position.x;
        shelterFixedPosition.z = goalShelter.transform.position.z;

        shelterDirection = GetGoalDirection(playerFixedPosition, shelterFixedPosition) * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(shelterDirection);
    }

    public Vector3 GetGoalDirection(Vector3 v1, Vector3 v2)
    {
        return (v1 - v2).normalized;
    }
}