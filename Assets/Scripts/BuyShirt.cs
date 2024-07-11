using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyShirt : MonoBehaviour
{

    [SerializeField] Button btnBuy;
    [SerializeField] ItemShirtSO itemShirtSO;

    private void Start() {

        btnBuy.onClick.AddListener(OnBuyShirt);

    }
    void OnBuyShirt() {

        if(Player.Instance.money >= itemShirtSO.price) {
            
            Player.Instance.money-=itemShirtSO.price;
            Player.Instance.moneyTextField.text = Player.Instance.money.ToString();

            Player.Instance.GetInventory().AddShirt(itemShirtSO);

        } else {

            

        }

    }

}
