using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private GameObject menuPanel;
    private GameObject howToPlayPanel;
    private GameObject creditsPanel;

    // <-- reference for button select stuff

    [SerializeField] private Button playButton;
    [SerializeField] private Button backCButton;
    [SerializeField] private Button backHButton;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            //Finding all the menu Panels
            menuPanel = GameObject.Find("Menu");
            howToPlayPanel = GameObject.Find("HowToPlay");
            creditsPanel = GameObject.Find("Credits");

            //Setiing up the menu for when the game starts
            menuPanel.SetActive(true);
            howToPlayPanel.SetActive(false);
            creditsPanel.SetActive(false);

            if (GameObject.Find("PlayerObjectOne") != null)
            {
                Destroy(GameObject.Find("PlayerObjectOne"));
            }

            if (GameObject.Find("PlayerObjectTwo") != null)
            {
                Destroy(GameObject.Find("PlayerObjectTwo"));
            }

            if (GameObject.Find("PlayerManager") != null)
            {
                Destroy(GameObject.Find("PlayerManager"));
            }
        }
        
    }

    public void PlayGame() //Playing the game
    {
        SceneManager.LoadScene(1); //Loads the scene the game will be played on
    }

    public void HowToPlay() //Goes to page that shows controls
    {
        //activating the How to play screen
        menuPanel.SetActive(false);
        howToPlayPanel.SetActive(true);

        /*
        Title: Controller and Keyboard Menu Navigation w/ Input System - Unity Tutorial
        Author: samyam
        Date: 20 Mar 2021
        Availability: https://www.youtube.com/watch?v=Hn804Wgr3KE
        Usage: How to get the right button to select at the right time  to set up controllers to move through UI
        */
        backHButton.Select();
    }

    public void Credits() //Goes to page that showcases any important references for the game eg: Inspirations
    {
        //Activating the credits screen
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);

        backCButton.Select();
    }

    public void Back()
    {
        //Going back to the main menu
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);
        menuPanel.SetActive(true);

        playButton.Select();
    }

    public void Menu()
    {

        SceneManager.LoadScene(0); //Takes players back to menu
    }

    public void Replay()
    {
        SceneManager.LoadScene(1); //Takes players back to waiting room
    }

    /*public void Stages() //The players can choose game mode they would like to play on this game.
    {

    }*/
}
