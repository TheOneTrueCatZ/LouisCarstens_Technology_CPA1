using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleShield : MonoBehaviour
{
    public GameObject shield;
    private bool shieldToggled = false;

    public void OnToggleShield(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shieldToggled = !shieldToggled;
            shield.SetActive(shieldToggled);
        }
    }
}
