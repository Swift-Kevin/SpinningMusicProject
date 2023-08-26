using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    UserInput input;

    public UserInput Input => input;
    public UserInput.MainActionActions Action => input.MainAction;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        input = new UserInput();
        input.MainAction.Enable();
        input.MainAction.ToggleMenus.performed += PerformToggleMenu;
    }

    private void OnDisable()
    {
        input.MainAction.ToggleMenus.performed -= PerformToggleMenu;
    }

    private void PerformToggleMenu(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        GameManager.Instance.TickMenuChanger();
    }
}
