using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance {  get; private set; }
    public Inventory inventory;

    [SerializeField] private RectTransform equippedTransform;
    [SerializeField] private RectTransform[] unequippedListTransform;
    [SerializeField] private Button[] sellButtonsList;
    [SerializeField] public Sprite transparentSprite;
    private bool ShopIsOpenedRef = false;

    private void Awake() {
        Instance = this;
    }
    void Start()
    {


    }

    private void InventoryUI_CheckSellButtonsOnShopOpen(bool ShopIsOpened) {

        if (ShopIsOpened == true) {

            for (int position = 0; position < 2; position++) {

                if (unequippedListTransform[position].GetComponent<Draggable>().itemShirtSO == null) {

                    sellButtonsList[position].gameObject.SetActive(false);

                } else {

                    sellButtonsList[position].gameObject.SetActive(true);

                }

            }

        } else {

            for (int position = 0; position < 2; position++) {

                    sellButtonsList[position].gameObject.SetActive(false);

            }

        }

        ShopIsOpenedRef = ShopIsOpened;

    }

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;

        inventory.OnRefreshInventory += InventoryUI_OnRefreshInventory;
        NPC.Instance.CheckSellButtonsOnShopOpen += InventoryUI_CheckSellButtonsOnShopOpen;

        Player.Instance.GetInventory().LoadInventory();

    }

    private void InventoryUI_OnRefreshInventory(object listItemShirtSO, System.EventArgs e) {
        RefreshInventory(listItemShirtSO as List<ItemShirtSO>);
    }

    void RefreshInventory(List<ItemShirtSO> itemShirtSOList) {

        for(int position = 0; position <2; position++) {

            if (itemShirtSOList[position] == null) {

                unequippedListTransform[position].GetComponent<Draggable>().itemShirtSO = null;
                unequippedListTransform[position].GetComponent<Image>().sprite = transparentSprite;

            } else {

                unequippedListTransform[position].GetComponent<Draggable>().itemShirtSO = itemShirtSOList[position];
                unequippedListTransform[position].GetComponent<Image>().sprite = itemShirtSOList[position].sprite;

            }

            sellButtonsList[position].gameObject.SetActive(false);

            if(ShopIsOpenedRef == true) {
                InventoryUI_CheckSellButtonsOnShopOpen(ShopIsOpenedRef);
            }

        }


    }
}
