using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using System.Collections.Generic;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private RoundsUI roundsUIScript;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject winTextOne;
    [SerializeField] private GameObject winTextTwo;
    [SerializeField] private GameObject roundsScreen;
    [SerializeField] private GameObject upgradeScreen;
    [SerializeField] private Button firtsButton;

    [SerializeField] private GameObject eventSystymObject;

    private void Start()
    {
        winScreen.SetActive(false);
    }

    //Sets up the win screen with the relevant information
    private void Update()
    {
        if (roundsUIScript.playerOneWins >= 2)
        {
            winScreen.SetActive(true);
            winTextOne.SetActive(true);
            winTextTwo.SetActive(false);
            roundsScreen.SetActive(false);
            upgradeScreen.SetActive(false);
            firtsButton.Select();

            /*
           Title: How can multiple users control a single UI canvas using InputSystem?
           Author: AlbertoVgdd
           Date: 14 March 2025
           Availability: https://discussions.unity.com/t/how-can-multiple-users-control-a-single-ui-canvas-using-inputsystem/245974
           Usage: Helped me figure out how to get one user only to use a certain part of the UI (Used this in else if as well)
           */

            //Makes the Event system use the action map attached to the relevant player
            eventSystymObject.GetComponent<InputSystemUIInputModule>().actionsAsset = GameObject.Find("PlayerObjectOne").transform.GetChild(0).GetComponent<PlayerInput>().actions;

            //Sets the relevant actions to the eventsystem actions needed to traverse the UI, like moc=ving between the buttons and selecting them
            eventSystymObject.GetComponent<InputSystemUIInputModule>().move = InputActionReference.Create(GameObject.Find("PlayerObjectOne").transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Navigation"));
            eventSystymObject.GetComponent<InputSystemUIInputModule>().submit = InputActionReference.Create(GameObject.Find("PlayerObjectOne").transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Select"));
        }
        else if (roundsUIScript.playerTwoWins >= 2)
        {
            winScreen.SetActive(true);
            winTextOne.SetActive(false);
            winTextTwo.SetActive(true);
            roundsScreen.SetActive(false);
            upgradeScreen.SetActive(false);
            firtsButton.Select();

            /*
           Title: How can multiple users control a single UI canvas using InputSystem?
           Author: AlbertoVgdd
           Date: 14 March 2025
           Availability: https://discussions.unity.com/t/how-can-multiple-users-control-a-single-ui-canvas-using-inputsystem/245974
           Usage: Helped me figure out how to get one user only to use a certain part of the UI (Used this in else if as well)
           */

            //Makes the Event system use the action map attached to the relevant player
            eventSystymObject.GetComponent<InputSystemUIInputModule>().actionsAsset = GameObject.Find("PlayerObjectOne").transform.GetChild(0).GetComponent<PlayerInput>().actions;

            //Sets the relevant actions to the eventsystem actions needed to traverse the UI, like moc=ving between the buttons and selecting them
            eventSystymObject.GetComponent<InputSystemUIInputModule>().move = InputActionReference.Create(GameObject.Find("PlayerObjectOne").transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Navigation"));
            eventSystymObject.GetComponent<InputSystemUIInputModule>().submit = InputActionReference.Create(GameObject.Find("PlayerObjectOne").transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Select"));
        }
    }
}
