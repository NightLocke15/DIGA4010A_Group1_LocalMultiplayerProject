using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    private GameObject menuPanel;
    private GameObject howToPlayPanel;
    private GameObject creditsPanel;

    private void Start()
    {
        //Finding all the menu Panels
        menuPanel = GameObject.Find("Menu");
        howToPlayPanel = GameObject.Find("HowToPlay");
        creditsPanel = GameObject.Find("Credits");

        //Setiing up the menu for when the game starts
        menuPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);
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
    }

    public void Credits() //Goes to page that showcases any important references for the game eg: Inspirations
    {
        //Activating the credits screen
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void Back()
    {
        //Going back to the main menu
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    /*public void Stages() //The players can choose game mode they would like to play on this game.
    {

    }*/
}
