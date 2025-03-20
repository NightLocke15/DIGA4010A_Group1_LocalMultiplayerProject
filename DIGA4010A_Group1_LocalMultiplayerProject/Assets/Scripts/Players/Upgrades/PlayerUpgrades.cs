using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class PlayerUpgrades : MonoBehaviour
{
    /* 1.
        Title:
        Author:
        Date:
        Code Version:
        Availability: https://discussions.unity.com/t/how-can-multiple-users-control-a-single-ui-canvas-using-inputsystem/245974
        Usage: Helped me figure out how to get one user only to use a certain part of the UI
     */

    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    [SerializeField] private GameObject playerOneUpgradePanel;
    [SerializeField] private GameObject playerTwoUpgradePanel;

    [SerializeField] private GameObject eventSystymObject;

    private void Start()
    {
        playerOne = GameObject.Find("PlayerObjectOne");
        playerTwo = GameObject.Find("PlayerObjectTwo");

        playerOneUpgradePanel = GameObject.Find("Player1Upgrades");
        playerTwoUpgradePanel = GameObject.Find("Player2Upgrades");

        playerOneUpgradePanel.SetActive(false);
        playerTwoUpgradePanel.SetActive(false);


        Debug.Log(playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap);
    }

    private void Update()
    {
        if (playerOne.GetComponent<PlayerInformationHandler>().playerLost == true)
        {
            //Opens the UI panel for player one's upgrades
            playerOneUpgradePanel.SetActive(true);

            //Selects the first button so the UI can be traversed with a controller
            playerOneUpgradePanel.transform.GetChild(0).GetComponent<Button>().Select();

            //Disables the movement of both the players so they cannot keep hitting one another while the UI is active
            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;

            //Makes the Losing player's action map the one used to use the UI
            playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "Menu";

            //Makes the Event system use the action map attached to the relevant player
            eventSystymObject.GetComponent<InputSystemUIInputModule>().actionsAsset = playerOne.transform.GetChild(0).GetComponent<PlayerInput>().actions; //1. in references

            //Sets the relevant actions to the eventsystem actions needed to traverse the UI, like moc=ving between the buttons and selecting them
            eventSystymObject.GetComponent<InputSystemUIInputModule>().move = InputActionReference.Create(playerOne.transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Navigation"));
            eventSystymObject.GetComponent<InputSystemUIInputModule>().submit = InputActionReference.Create(playerOne.transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Select"));

            //Setting player back to not losing, so the game can continue
            playerOne.GetComponent<PlayerInformationHandler>().playerLost = false;
        }
        else if (playerTwo.GetComponent<PlayerInformationHandler>().playerLost == true)
        {
            //This is the same as above, just for player two
            playerTwoUpgradePanel.SetActive(true);

            playerTwoUpgradePanel.transform.GetChild(0).GetComponent<Button>().Select();

            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;

            playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "Menu";

            eventSystymObject.GetComponent<InputSystemUIInputModule>().actionsAsset = playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().actions; //1. in references

            eventSystymObject.GetComponent<InputSystemUIInputModule>().move = InputActionReference.Create(playerTwo.transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Navigation"));
            eventSystymObject.GetComponent<InputSystemUIInputModule>().submit = InputActionReference.Create(playerTwo.transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Select"));

            playerTwo.GetComponent<PlayerInformationHandler>().playerLost = false;
        }
    }

    public void UpgradeTest()
    {
        if (playerOneUpgradePanel.activeSelf == true)
        {
            Debug.Log("Upgrade Chosen");
            //Sets the player back to starting positions
            playerOne.transform.GetChild(0).position = new Vector3(-6, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(6, 3);

            //Sets the health of the players back to full
            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;   
            
            //Enables the player's movements again
            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;

            //AudioSettings the player action map back to it's movement
            playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";

            //Switching off UI panel
            playerOneUpgradePanel.SetActive(false);
          
            
        }
        else if (playerTwoUpgradePanel.activeSelf == true)
        {
            //The same as above just for player two
            Debug.Log("Upgrade Chosen");
            playerOne.transform.GetChild(0).position = new Vector3(-6, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(6, 3);

            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;

            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;

            playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";

            playerTwoUpgradePanel.SetActive(false);
            
           
        }
    }
}
