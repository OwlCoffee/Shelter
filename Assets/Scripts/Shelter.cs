using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    private string shelterTag = "None";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player") && shelterTag.Equals("GoalShelter"))
        {
            SceneLoader.Instance.LoadShelterScene();
        }
    }

    public void SetShelterTag(string tagName)
    {
        this.shelterTag = tagName;
    }
}
