using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Life
{
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float moveSpeed;
    private float gravity;
    private float characterSpeed;

    private Ray cameraRay;
    private Plane groupPlane;
    private float rayDistance;

    private GunController gunController;

    private Animator characterAnimator;

    private float playerMaxHealth;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        playerMaxHealth = 150.0f;
        SetMaxHealth(playerMaxHealth);

#if UNITY_EDITOR
        Debug.Log("Player's Max health " + maxHealth);
#endif

        // Character Movement
        characterController = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
        moveSpeed = 5.0f;
        gravity = 10.0f;
        groupPlane = new Plane(Vector3.up, Vector3.zero);

        // Gun Controller
        gunController = GetComponent<GunController>();

        // Character Animation
        characterAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        moveDirection.y -= gravity * Time.deltaTime;

        characterSpeed = Mathf.Sqrt(Vector3.Dot(moveDirection, moveDirection));
        characterController.Move(moveDirection * Time.deltaTime);
        characterAnimator.SetFloat("Move", characterSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Input keyboard button for character movement
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= moveSpeed;
        }

        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (groupPlane.Raycast(cameraRay, out rayDistance))
        {
            Vector3 lookPoint = cameraRay.GetPoint(rayDistance);
            transform.LookAt(new Vector3(lookPoint.x, transform.position.y, lookPoint.z));
        }

        // Input mouse button
        if (Input.GetMouseButton(0))
        {
            gunController.FireButton();
        }

//#if UNITY_EDITOR
//        Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);
//#endif
    }
}
