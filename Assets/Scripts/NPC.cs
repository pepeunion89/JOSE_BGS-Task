using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    public static NPC Instance { get; private set; }

    [SerializeField] private SpriteRenderer spriteMessage;
    [SerializeField] private Transform ShopUIImage;
    [SerializeField] Button[] sellButtonsList;
    public bool ShopIsOpened = false;
    public delegate void CustomEventHandler(bool shopIsOpenedInt); 
    public event CustomEventHandler CheckSellButtonsOnShopOpen;


    private void Awake() {
        Instance = this;
    }
    public void Interact() {

        ShopIsOpened = !ShopIsOpened;

        ShopUIImage.gameObject.SetActive(ShopIsOpened);

        CheckSellButtonsOnShopOpen.Invoke(ShopIsOpened);

    }

    public void ShowInteractMessage(bool showing) {

        spriteMessage.gameObject.SetActive(showing);

        if(showing == false) {
            ShopIsOpened = false;
            ShopUIImage.gameObject.SetActive(ShopIsOpened);
            CheckSellButtonsOnShopOpen.Invoke(ShopIsOpened);
        }

    }
}
