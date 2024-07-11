using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public static Player Instance { get; private set; }

    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Image inventoryUIImage;
    [SerializeField] private InventoryUI inventoryUIImageScript;
    [SerializeField] public TextMeshProUGUI moneyTextField;
    [SerializeField] public int money;

    private float maxRotationAngle = 7f; 
    private float rotationSpeed = 25f; 
    private float rotationTime = 0f;

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
        inventoryUIImageScript.SetInventory(inventory);

        money = 100;

    }
    void Start()
    {
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

        if (moveDirection.x != 0 || moveDirection.y != 0) {
            rotationTime += Time.deltaTime * rotationSpeed;
            float rotationAngle = Mathf.Sin(rotationTime) * maxRotationAngle;
            gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);
        } else {
            gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0);
            rotationTime = 0f; 
        }

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
