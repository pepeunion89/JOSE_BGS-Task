using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{

    public static AnimatorManager Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    [SerializeField] public Animator GreenAnimation;
    [SerializeField] public Animator ManchesterCityAnimation;
    [SerializeField] public Animator ManchesterUnitedAnimation;

    [SerializeField] public Sprite GreenSprite;
    [SerializeField] public Sprite ManchesterCitySprite;
    [SerializeField] public Sprite ManchesterUnitedSprite;

}
