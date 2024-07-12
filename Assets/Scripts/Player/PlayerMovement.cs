using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Range(1f, 5f)]
    [SerializeField] public float movementSpeed = 1.0f;
    [SerializeField] public Rigidbody2D player;
    private Vector2 direction;
    private Animator animator;

    public void HandleMovement(Vector2 movementDirection) {
        direction = movementDirection * movementSpeed;
        player.velocity = direction;
    }

    public void UpdateDirectionMovementAnimation(Vector2 movementDirection, Transform boy) {
        if (animator == null) {
            animator = boy.GetComponent<Animator>();
            if (animator == null) {
                Debug.LogError("Animator not found on " + boy.name);
                return;
            }
        }

        ResetAllAnimationBools();

        if (movementDirection == Vector2.zero) {
            // No movement
            return;
        }

        if (Mathf.Approximately(movementDirection.x, 0) && Mathf.Approximately(movementDirection.y, 1)) {

            animator.SetBool(Constants.PlayerConstants.IsWalkingUp, true);

        } else if (Mathf.Approximately(movementDirection.x, 1) && Mathf.Approximately(movementDirection.y, 0)) {

            animator.SetBool(Constants.PlayerConstants.IsWalkingRight, true);

        } else if (Mathf.Approximately(movementDirection.x, 0) && Mathf.Approximately(movementDirection.y, -1)) {

            animator.SetBool(Constants.PlayerConstants.IsWalkingDown, true);

        } else if (Mathf.Approximately(movementDirection.x, -1) && Mathf.Approximately(movementDirection.y, 0)) {

            animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, true);

        } else if (Mathf.Approximately(movementDirection.x, 0.707f) && Mathf.Approximately(movementDirection.y, 0.707f)) {

            animator.SetBool(Constants.PlayerConstants.IsWalkingUp, true);

        } else if (Mathf.Approximately(movementDirection.x, -0.707f) && Mathf.Approximately(movementDirection.y, 0.707f)) {

            animator.SetBool(Constants.PlayerConstants.IsWalkingUp, true);

        } else if (Mathf.Approximately(movementDirection.x, 0.707f) && Mathf.Approximately(movementDirection.y, -0.707f)) {

            animator.SetBool(Constants.PlayerConstants.IsWalkingDown, true);

        } else if (Mathf.Approximately(movementDirection.x, -0.707f) && Mathf.Approximately(movementDirection.y, -0.707f)) {

            animator.SetBool(Constants.PlayerConstants.IsWalkingDown, true);
        }
    }

    private void ResetAllAnimationBools() {
        animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
        animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
        animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
        animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
    }
}