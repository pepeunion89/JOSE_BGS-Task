using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button ExitButton;    
    [SerializeField] private Transform Menu;
    private bool openMenu = false;

    private void Awake() {

        OptionsButton.onClick.AddListener(ToggleOptionsMenu);
        ResumeButton.onClick.AddListener(ToggleOptionsMenu);
        ExitButton.onClick.AddListener(ExitGame);

    }

    void ToggleOptionsMenu() {

        openMenu = !openMenu;

        Menu.gameObject.SetActive(openMenu);

    }

    void ExitGame() {

        Application.Quit();

    }

}
