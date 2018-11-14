using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float jumpForce = 10f;
    private string paramIsDead = "isDead";
    private string paramYVelocity = "yVelocity";
    private Rigidbody rigidbody;
    private Animator animator;
    private bool isJumping;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        CheckForInput();
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        HandleJump();
    }

    private void UpdateAnimator()
    {
        animator.SetFloat(paramYVelocity, rigidbody.velocity.y);
    }

    private void HandleJump()
    {
        if (isJumping)
        {
            isJumping = false;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }

    private void CheckForInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isJumping = true;
        }
    }
}
