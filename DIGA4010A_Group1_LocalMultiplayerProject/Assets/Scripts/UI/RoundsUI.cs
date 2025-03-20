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
        for (int i = 0; i < rounds.Count; i++)
        {
            if(!rounds[i].isOn)
            {
                rounds[i].GetComponentInChildren<Image>().color = colour;
                rounds[i].isOn = enabled;

                return;
            }
            else
            {

            }
        }
    }
}
