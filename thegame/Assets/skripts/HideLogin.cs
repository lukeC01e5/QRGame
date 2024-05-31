using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLogin : MonoBehaviour
{
    // Reference to the login page GameObject
    public GameObject loginPage;

    // Reference to the PlayerController
    public PlayerController playerController;



    private void Start()
    {
        // Disable the PlayerController script when the login page is active
        if (playerController != null)
        {
            playerController.enabled = false;
        }
    }

    // Method to hide the login page
    public void HideLoginPage()
    {
        if (loginPage != null)
        {
            loginPage.SetActive(false);

            // Enable the PlayerController script when the login page is hidden
            if (playerController != null)
            {
                playerController.enabled = true;
            }
        }
    }
}