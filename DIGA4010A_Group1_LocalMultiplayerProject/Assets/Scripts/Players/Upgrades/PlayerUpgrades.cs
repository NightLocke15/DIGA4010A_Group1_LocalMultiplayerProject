using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using System.Collections.Generic;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    [SerializeField] private GameObject playerOneUpgradePanel;
    [SerializeField] private GameObject playerTwoUpgradePanel;

    [SerializeField] private GameObject eventSystymObject;

    public List<GameObject> upgradesOne = new List<GameObject>();
    public List<GameObject> upgradesTwo = new List<GameObject>();

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

            int number = Random.Range(0, upgradesOne.Count);

            for (int i = 0; i < upgradesOne.Count; i++)
            {
                if (i == number)
                {
                    upgradesOne[i].SetActive(true);
                    //Selects the button so the UI can be traversed with a controller
                    upgradesOne[i].GetComponent<Button>().Select();
                }
                else
                {
                    upgradesOne[i].SetActive(false);
                }
            }

            //Disables the movement of both the players so they cannot keep hitting one another while the UI is active
            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;

            playerOne.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = false;
            playerTwo.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = false;

            //Makes the Losing player's action map the one used to use the UI
            playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "Menu";

            /*
            Title: How can multiple users control a single UI canvas using InputSystem?
            Author: AlbertoVgdd
            Date: 14 March 2025
            Availability: https://discussions.unity.com/t/how-can-multiple-users-control-a-single-ui-canvas-using-inputsystem/245974
            Usage: Helped me figure out how to get one user only to use a certain part of the UI (Used this in else if as well)
            */

            //Makes the Event system use the action map attached to the relevant player
            eventSystymObject.GetComponent<InputSystemUIInputModule>().actionsAsset = playerOne.transform.GetChild(0).GetComponent<PlayerInput>().actions; 

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

            int number = Random.Range(0, upgradesTwo.Count);

            for (int i = 0; i < upgradesTwo.Count; i++)
            {
                if (i == number)
                {
                    upgradesTwo[i].SetActive(true);
                    upgradesTwo[i].GetComponent<Button>().Select();
                }
                else
                {
                    upgradesTwo[i].SetActive(false);
                    
                }
            }

            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;

            playerOne.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = false;
            playerTwo.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = false;

            playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "Menu";

            eventSystymObject.GetComponent<InputSystemUIInputModule>().actionsAsset = playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().actions; 

            eventSystymObject.GetComponent<InputSystemUIInputModule>().move = InputActionReference.Create(playerTwo.transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Navigation"));
            eventSystymObject.GetComponent<InputSystemUIInputModule>().submit = InputActionReference.Create(playerTwo.transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Select"));

            playerTwo.GetComponent<PlayerInformationHandler>().playerLost = false;
        }
    }

    public void HigherKnockbackUpgrade()
    {
        if (playerOneUpgradePanel.activeSelf == true)
        {
            playerOne.GetComponent<PlayerInformationHandler>().higherKnockback = true;

            //Sets the player back to starting positions
            playerOne.transform.GetChild(0).position = new Vector3(-6, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(6, 3);

            //Sets the health of the players back to full
            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;   
            
            //Enables the player's movements again
            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;

            playerOne.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;
            playerTwo.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;

            //AudioSettings the player action map back to it's movement
            playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";

            //Switching off UI panel
            playerOneUpgradePanel.SetActive(false);
          
            
        }
        else if (playerTwoUpgradePanel.activeSelf == true)
        {
            playerTwo.GetComponent<PlayerInformationHandler>().higherKnockback = true;

            //The same as above just for player two
            Debug.Log("Upgrade Chosen");
            playerOne.transform.GetChild(0).position = new Vector3(-6, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(6, 3);

            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;

            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;

            playerOne.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;
            playerTwo.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;

            playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";

            playerTwoUpgradePanel.SetActive(false);
            
           
        }
    }

    public void HigherHealthUpgrade()
    {
        if (playerOneUpgradePanel.activeSelf == true)
        {
            playerOne.GetComponent<PlayerInformationHandler>().higherHealth = true;
            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue = 120;

            //Sets the player back to starting positions
            playerOne.transform.GetChild(0).position = new Vector3(-6, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(6, 3);

            //Sets the health of the players back to full
            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;

            //Enables the player's movements again
            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;

            playerOne.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;
            playerTwo.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;

            //AudioSettings the player action map back to it's movement
            playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";

            //Switching off UI panel
            playerOneUpgradePanel.SetActive(false);


        }
        else if (playerTwoUpgradePanel.activeSelf == true)
        {
            playerTwo.GetComponent<PlayerInformationHandler>().higherHealth = true;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue = 120;

            //The same as above just for player two
            Debug.Log("Upgrade Chosen");
            playerOne.transform.GetChild(0).position = new Vector3(-6, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(6, 3);

            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;

            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;

            playerOne.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;
            playerTwo.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;

            playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";

            playerTwoUpgradePanel.SetActive(false);


        }
    }

    public void HigherSpeedUpgrade()
    {
        if (playerOneUpgradePanel.activeSelf == true)
        {
            playerOne.GetComponent<PlayerInformationHandler>().fasterMovingWeapon = true;

            //Sets the player back to starting positions
            playerOne.transform.GetChild(0).position = new Vector3(-6, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(6, 3);

            //Sets the health of the players back to full
            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;

            //Enables the player's movements again
            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;

            playerOne.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;
            playerTwo.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;

            //AudioSettings the player action map back to it's movement
            playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";

            //Switching off UI panel
            playerOneUpgradePanel.SetActive(false);


        }
        else if (playerTwoUpgradePanel.activeSelf == true)
        {
            playerTwo.GetComponent<PlayerInformationHandler>().fasterMovingWeapon = true;

            //The same as above just for player two
            Debug.Log("Upgrade Chosen");
            playerOne.transform.GetChild(0).position = new Vector3(-6, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(6, 3);

            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;

            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;

            playerOne.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;
            playerTwo.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;

            playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";

            playerTwoUpgradePanel.SetActive(false);


        }
    }

    public void BombUpgrade() 
    { 
        if (playerOneUpgradePanel.activeSelf == true)
        {
            playerOne.GetComponent<PlayerInformationHandler>().chuckBomb = true;

            //Sets the player back to starting positions
            playerOne.transform.GetChild(0).position = new Vector3(-6, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(6, 3);

            //Sets the health of the players back to full
            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;

            //Enables the player's movements again
            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;

            playerOne.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;
            playerTwo.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;

            //AudioSettings the player action map back to it's movement
            playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";

            //Switching off UI panel
            playerOneUpgradePanel.SetActive(false);


        }
        else if (playerTwoUpgradePanel.activeSelf == true)
        {
            playerTwo.GetComponent<PlayerInformationHandler>().chuckBomb = true;

            //The same as above just for player two
            Debug.Log("Upgrade Chosen");
            playerOne.transform.GetChild(0).position = new Vector3(-6, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(6, 3);

            playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = playerOne.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;
            playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.maxValue;

            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;

            playerOne.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;
            playerTwo.transform.GetChild(1).GetComponent<PlayerHammerInteractions>().enabled = true;

            playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";

            playerTwoUpgradePanel.SetActive(false);


        }
    }
}
