using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2;
    private Animator animator;

    private PlayerCamera playerCamera;

    public bool isMoveable { get; private set; } = true;

    public float movementSpeed = 2;
    public float movementSpeedMax = 4;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCamera = RoomMaster.playerCamera;
    }

    void Update()
    {
        WalkingControl();
    }

    void WalkingControl()
    {
        if (isMoveable && playerCamera.IsFadeOut)
        {
            float posX = Input.GetAxisRaw("Horizontal");
            float posY = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(posX, posY).normalized * movementSpeed;

            rb2.velocity = movement;

            WalkingAnimationControl(movement);
        }
    }

    void WalkingAnimationControl(Vector2 movement)
    {
        if (animator)
        {
            animator.SetBool("isIdle", movement.magnitude == 0);
            animator.SetFloat("horizontalCondition", movement.x);
            animator.SetFloat("verticalCondition", movement.y);
        }
    }

    public void DisableMovement()
    {
        isMoveable = false;
    }

    public void EnableMovement()
    {
        isMoveable = true;
    }
}
