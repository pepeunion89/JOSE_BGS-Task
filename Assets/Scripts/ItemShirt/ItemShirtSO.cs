using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New shirt", menuName = "ItemShirtSO/create")]
public class ItemShirtSO : ScriptableObject
{
    public string itemShirtName;
    public int price;
    public Sprite sprite;

}
