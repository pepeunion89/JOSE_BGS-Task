using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellShirt : MonoBehaviour
{

    [SerializeField] private Button sellButton;
    [SerializeField] private RectTransform unequippedSlot;

    private void Awake() {

        sellButton.onClick.AddListener(OnSellShirt);

    }

    void OnSellShirt() {

        ItemShirtSO isSO = unequippedSlot.GetComponent<Draggable>().itemShirtSO;
        int idxSlot = unequippedSlot.GetComponent<Draggable>().idxSlot;

        List <ItemShirtSO> itemShirtSOlist = Player.Instance.GetInventory().GetItemShirtList();

        Player.Instance.money += isSO.price;
        Player.Instance.moneyTextField.text = Player.Instance.money.ToString();

        itemShirtSOlist[idxSlot] = null;

        Player.Instance.GetInventory().RemoveShirt();

    }

}
