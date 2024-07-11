using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
   
    private List<ItemShirtSO> listItemShirtSO;
    public event EventHandler OnRefreshInventory;
    public Inventory() {

        listItemShirtSO = new List<ItemShirtSO>(3);
        for(int itemShirtCounter = 0; itemShirtCounter < 3; itemShirtCounter++) {
            listItemShirtSO.Add(null);
        }

    }

    public void AddShirt(ItemShirtSO shirtSO) {

        int flag = 0;

        for(int counter = 0; counter < 2; counter++) {

            if (listItemShirtSO[counter] == null && flag == 0) {

                ItemShirtSO isSO = shirtSO;
                listItemShirtSO[counter] = isSO;

                flag = 1;
            }

        }

        OnRefreshInventory.Invoke(listItemShirtSO, EventArgs.Empty);

    }

    public void RemoveShirt() {

        OnRefreshInventory.Invoke(listItemShirtSO, EventArgs.Empty);

    }

    public List<ItemShirtSO> GetItemShirtList() {
        return listItemShirtSO;
    }

    public void LoadInventory() {
        OnRefreshInventory.Invoke(listItemShirtSO, EventArgs.Empty);
    }
}
