using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShirtAssets : MonoBehaviour
{
    
    public static ItemShirtAssets Instance {  get; private set; }

    private void Awake() {
        Instance = this;
    }

    public Sprite ManchesterUnitedShirt;
    public Sprite ManchesterCityShirt;

}
