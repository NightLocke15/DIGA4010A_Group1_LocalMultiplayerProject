using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoundsUI : MonoBehaviour
{
    public List<Toggle> rounds = new List<Toggle>();

    public int playerOneWins;
    public int playerTwoWins;

    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    public bool playerOneScore;
    public bool playerTwoScore;

    private void Start()
    {
        playerOne = GameObject.Find("PlayerObjectOne");
        playerTwo = GameObject.Find("PlayerObjectTwo");
    }

    private void Update()
    {
        //Tracking when a player wins a round. Changes the next one in the list to the relevant colour
        if (playerOneScore == true)
        {
            playerOneWins += 1;
            RoundWon(new Color32(253, 0, 62, 255));
            playerOneScore = false;
        }
        else if (playerTwoScore == true)
        {
            playerTwoWins += 1;
            RoundWon(new Color32(9, 253, 0, 255));
            playerTwoScore = false;
        }
    }

    //Changes the colour of the circle when a player has won
    private void RoundWon(Color32 colour)
    {
        if (playerOneScore == true)
        {
            if (!rounds[0].isOn)
            {
                rounds[0].GetComponentInChildren<Image>().color = colour;
                rounds[0].isOn = enabled;

                return;
            }
            else
            {
                rounds[1].GetComponentInChildren<Image>().color = colour;
                rounds[1].isOn = enabled;

                return;
            }
        }
        else if (playerTwoScore == true)
        {
            if (!rounds[2].isOn)
            {
                rounds[2].GetComponentInChildren<Image>().color = colour;
                rounds[2].isOn = enabled;

                return;
            }
            else
            {
                rounds[1].GetComponentInChildren<Image>().color = colour;
                rounds[1].isOn = enabled;

                return;
            }
        }
    }
}
