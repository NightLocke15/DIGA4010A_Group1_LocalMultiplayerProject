using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class PlayerUpgrades : MonoBehaviour
{
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
        //if (playerOne.GetComponent<PlayerInformationHandler>().playerLost == true)
        //{
        //    playerOneUpgradePanel.SetActive(true);
        //    playerOneUpgradePanel.transform.GetChild(0).GetComponent<Button>().Select();
        //    playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
        //    playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
        //    playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().DeactivateInput();
        //    playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "Menu";
        //    playerOne.GetComponent<PlayerInformationHandler>().playerLost = false;
        //}
        //else if (playerTwo.GetComponent<PlayerInformationHandler>().playerLost == true)
        //{
        //    playerTwoUpgradePanel.SetActive(true);
        //    playerTwoUpgradePanel.transform.GetChild(0).GetComponent<Button>().Select();
        //    playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
        //    playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
        //    playerOne.transform.GetChild(0).GetComponent<PlayerInput>().DeactivateInput();
        //    playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "Menu";
        //    playerTwo.GetComponent<PlayerInformationHandler>().playerLost = false;
        //}

        if (playerOne.GetComponent<PlayerInformationHandler>().playerLost == true)
        {
            playerOneUpgradePanel.SetActive(true);
            playerOneUpgradePanel.transform.GetChild(0).GetComponent<Button>().Select();
            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
            playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "Menu";
            eventSystymObject.GetComponent<InputSystemUIInputModule>().actionsAsset = playerOne.transform.GetChild(0).GetComponent<PlayerInput>().actions;
            eventSystymObject.GetComponent<InputSystemUIInputModule>().move = InputActionReference.Create(playerOne.transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Navigation"));
            eventSystymObject.GetComponent<InputSystemUIInputModule>().submit = InputActionReference.Create(playerOne.transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Select"));
            playerOne.GetComponent<PlayerInformationHandler>().playerLost = false;
        }
        else if (playerTwo.GetComponent<PlayerInformationHandler>().playerLost == true)
        {
            playerTwoUpgradePanel.SetActive(true);
            playerTwoUpgradePanel.transform.GetChild(0).GetComponent<Button>().Select();
            playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
            playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
            playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "Menu";
            eventSystymObject.GetComponent<InputSystemUIInputModule>().actionsAsset = playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().actions;
            eventSystymObject.GetComponent<InputSystemUIInputModule>().move = InputActionReference.Create(playerTwo.transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Navigation"));
            eventSystymObject.GetComponent<InputSystemUIInputModule>().submit = InputActionReference.Create(playerTwo.transform.GetChild(0)
                .GetComponent<PlayerInput>().actions.FindActionMap("Menu").FindAction("Select"));
            playerTwo.GetComponent<PlayerInformationHandler>().playerLost = false;
        }
    }

    private void UpgradeTest()
    {
        //if (playerOneUpgradePanel.activeSelf == true)
        //{
        //    Debug.Log("Upgrade Chosen");
        //    playerOne.GetComponent<PlayerInformationHandler>().playerHealth.value = 100;
        //    playerOne.transform.position = new Vector3(-6, 3);
        //    playerTwo.transform.position = new Vector3(6, 3);
        //    playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
        //    playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
        //    playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().ActivateInput();
        //    playerOne.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";
        //    playerOneUpgradePanel.SetActive(false);
            
            
        //}
        //else if (playerTwoUpgradePanel.activeSelf == true)
        //{
        //    Debug.Log("Upgrade Chosen");
        //    playerTwo.GetComponent<PlayerInformationHandler>().playerHealth.value = 100;
        //    playerOne.transform.position = new Vector3(-6, 3);
        //    playerTwo.transform.position = new Vector3(6, 3);
        //    playerOne.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
        //    playerTwo.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
        //    playerOne.transform.GetChild(0).GetComponent<PlayerInput>().ActivateInput();
        //    playerTwo.transform.GetChild(0).GetComponent<PlayerInput>().defaultActionMap = "PlayerController";
        //    playerTwoUpgradePanel.SetActive(false);
            
           
        //}
    }
}
