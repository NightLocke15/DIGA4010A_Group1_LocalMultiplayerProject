using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(2);
        }

        if (playerOne == null || playerTwo == null)
        {
            SetPlayers();
        }
        else
        {
            if (playerOne.GetComponent<PlayerInformationHandler>().startGame == true && playerTwo.GetComponent<PlayerInformationHandler>().startGame == true)
            {
                Debug.Log("Start Game");
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
