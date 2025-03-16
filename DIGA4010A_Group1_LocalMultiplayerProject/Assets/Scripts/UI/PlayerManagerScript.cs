using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;
    private bool start;

    [SerializeField] private TextMeshProUGUI waitingRoomText;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(2);
        }

        if (playerOne == null || playerTwo == null)
        {
            waitingRoomText.text = "Press A to Join";
            SetPlayers();
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "WaitingRoom")
            {
                waitingRoomText.text = "Hold Right Trigger to start game";
            }
            

            if (playerOne.GetComponent<PlayerInformationHandler>().startGame == true && playerTwo.GetComponent<PlayerInformationHandler>().startGame == true)
            {
                playerOne.transform.position = new Vector3(-18, 3);
                playerTwo.transform.position = new Vector3(18, 3);
                SceneManager.LoadScene(2);
                
            }
        }      
    }

    private void SetPlayers()
    {
        if (GameObject.Find("PlayerObjectOne") == null || GameObject.Find("PlayerObjectTwo") == null)
        {

        }
        else
        {
            playerOne = GameObject.Find("PlayerObjectOne");
            playerTwo = GameObject.Find("PlayerObjectTwo");
        }
    }
}
