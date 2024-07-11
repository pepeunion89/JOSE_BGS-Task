using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1f, 5f)]
    [SerializeField] public float movementSpeed = 1.0f;
    [SerializeField] public Rigidbody2D player;
    private Vector2 direction;
    public void HandleMovement(Vector2 movementDirection) {

        direction = movementDirection * movementSpeed;
        player.velocity = direction;

    }

}
