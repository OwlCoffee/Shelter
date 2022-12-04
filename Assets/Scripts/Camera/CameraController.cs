using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject character;

    private Vector3 cameraPositionOffset;
    private Vector3 cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        cameraPositionOffset = new Vector3(0.0f, 15.0f, -15.0f);
        cameraRotation = new Vector3(45.0f, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(cameraRotation);
    }

    private void LateUpdate()
    {
        if (character != null) transform.position = character.transform.position + cameraPositionOffset;
    }
}
