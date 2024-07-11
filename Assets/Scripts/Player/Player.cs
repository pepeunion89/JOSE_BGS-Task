using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public static Player Instance { get; private set; }

    [SerializeField] public Transform boy;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Image inventoryUIImage;
    [SerializeField] private InventoryUI inventoryUIImageScript;
    [SerializeField] public TextMeshProUGUI moneyTextField;
    [SerializeField] public int money;

    private bool showingMessage;
    public bool openInventory = false;
    private IInteractable currentInteractable;

    private Inventory inventory;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

        inventory = new Inventory();

        money = 100;

    }
    void Start() {

        inventoryUIImageScript.SetInventory(inventory);

        playerController.OnInteractAction += Player_OnInteractAction;
        playerController.OnInventoryAction += Player_OnInventoryAction;

        moneyTextField.text = money.ToString();

    }

    private void Player_OnInteractAction(InputAction.CallbackContext context) {
        if (currentInteractable != null) {
            currentInteractable.Interact();
        }
    }
    private void Player_OnInventoryAction(InputAction.CallbackContext context) {
        openInventory = !openInventory;
        inventoryUIImage.gameObject.SetActive(openInventory);
    }


    void FixedUpdate()
    {

        MovePlayer();
        
    }

    private void MovePlayer() {

        Vector2 moveDirection = playerController.GetMovementNormalized();

        playerMovement.HandleMovement(moveDirection);

        playerMovement.UpdateDirectionMovementAnimation(moveDirection, boy);

    }


    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.TryGetComponent(out IInteractable interactable)) {

            showingMessage = true;
            interactable.ShowInteractMessage(showingMessage);

            currentInteractable = interactable;
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {

        if (collision.TryGetComponent(out IInteractable interactable) && interactable == currentInteractable) {

            showingMessage = false;
            interactable.ShowInteractMessage(showingMessage);

            currentInteractable = null;

        }
                
    }

    public Inventory GetInventory() {
        return inventory;
    }
}
