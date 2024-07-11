using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance { get; private set; }

    [SerializeField] public PlayerInputActions playerInputActions;

    public event Action<InputAction.CallbackContext> OnInteractAction;
    public event Action<InputAction.CallbackContext> OnEscAction;
    public event Action<InputAction.CallbackContext> OnInventoryAction;

    private void Awake() {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        playerInputActions.Player.Interact.performed += PlayerController_OnInteractAction;
        playerInputActions.Player.Inventory.performed += PlayerController_OnInventoryAction;
        playerInputActions.Player.Exit.performed += PlayerController_OnEscAction;

    }

    private void PlayerController_OnInteractAction(InputAction.CallbackContext context) {
        OnInteractAction?.Invoke(context);
    }

    private void PlayerController_OnInventoryAction(InputAction.CallbackContext context) {
        OnInventoryAction?.Invoke(context);
    }

    private void PlayerController_OnEscAction(InputAction.CallbackContext context) {
        OnEscAction?.Invoke(context);
    }

    public Vector2 GetMovementNormalized() {

        Vector2 movementDirection = playerInputActions.Player.Move.ReadValue<Vector2>();

        movementDirection = movementDirection.normalized;

        return movementDirection;

    }
   
}