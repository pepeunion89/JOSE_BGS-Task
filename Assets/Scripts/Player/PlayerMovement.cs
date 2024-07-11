using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1f, 5f)]
    [SerializeField] public float movementSpeed = 1.0f;
    [SerializeField] public Rigidbody2D player;
    private Vector2 direction;
    private int flagStart = 0;
    private Animator animator;
    public void HandleMovement(Vector2 movementDirection) {

        direction = movementDirection * movementSpeed;
        player.velocity = direction;

    }

    public void UpdateDirectionMovementAnimation(Vector2 movementDirection, Transform boy) {

        if(flagStart == 0) {

            animator = boy.GetComponent<Animator>();

            flagStart = 1;
        }

        if(flagStart == 1) {

            Debug.Log(Math.Truncate(direction.x * 10));
            if (direction.x == 0 && direction.y == 5) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
            }

            if (direction.x == 5 && direction.y == 0) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
            }

            if (direction.x == 0 && direction.y == -5) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
            }

            if (direction.x == -5 && direction.y == 0) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
            }

            if (Math.Truncate(direction.x * 10) == 35 && Math.Truncate(direction.y * 10) == 35) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
            }

            if (Math.Truncate(direction.x * 10) == -35 && Math.Truncate(direction.y * 10) == 35) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
            }

            if (Math.Truncate(direction.x * 10) == 35 && Math.Truncate(direction.y * 10) == -35) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
            }

            if (Math.Truncate(direction.x * 10) == -35 && Math.Truncate(direction.y * 10) == -35) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
            }

            if (direction.x == 0 && direction.y == 0) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
            }

        }

    }

}
