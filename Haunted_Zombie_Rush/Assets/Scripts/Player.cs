﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;

    private string paramIsDead = "isDead";
    private string paramYVelocity = "yVelocity";
    private Rigidbody rigidbody;
    private Animator animator;
    private bool isJumping;
    private AudioSource audioSource;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        Assert.IsNotNull(audioSource); // sprawdza czy prawda i jesli nie wyrzuca wyjatek, innymi slowy sprawdzamy czy np Player posiada AudioSource Component
        Assert.IsNotNull(rigidbody);
        Assert.IsNotNull(animator);
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
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
        if(!GameManager.Instance.GameOver && GameManager.Instance.GameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.PlayerStartedGame();
                rigidbody.useGravity = true;
                isJumping = true;
                audioSource.PlayOneShot(sfxJump);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                audioSource.PlayOneShot(sfxDeath);
                rigidbody.AddForce(new Vector3(jumpForce / 3, jumpForce, -jumpForce / 2), ForceMode.Impulse);
                GameManager.Instance.PlayerCollided();
                break;
        }
    }
}
