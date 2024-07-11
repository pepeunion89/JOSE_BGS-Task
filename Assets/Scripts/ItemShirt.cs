using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShirt
{
    
    public enum ItemShirtType {
        ManchesterUnitedShirt,
        ManchesterCityShirt
    }

    private ItemShirtType itemShirtType;

    public Sprite GetSprite() {

        switch (itemShirtType) {

            default:

            case ItemShirtType.ManchesterUnitedShirt:

                return ItemShirtAssets.Instance.ManchesterUnitedShirt;

            case ItemShirtType.ManchesterCityShirt:

                return ItemShirtAssets.Instance.ManchesterCityShirt;

        }

    }

}
