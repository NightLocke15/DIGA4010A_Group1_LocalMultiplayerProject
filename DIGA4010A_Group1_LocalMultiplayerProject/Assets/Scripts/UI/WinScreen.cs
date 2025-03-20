using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private RoundsUI roundsUIScript;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private GameObject roundsScreen;
    [SerializeField] private GameObject upgradeScreen;

    private void Start()
    {
        winScreen.SetActive(false);
    }

    private void Update()
    {
        if (roundsUIScript.playerOneWins >= 2)
        {
            winScreen.SetActive(true);
            winText.text = "Player 1 Wins!";
            roundsScreen.SetActive(false);
            upgradeScreen.SetActive(false);
        }
        else if (roundsUIScript.playerTwoWins >= 2)
        {
            winScreen.SetActive(true);
            winText.text = "Player 2 Wins!";
            roundsScreen.SetActive(false);
            upgradeScreen.SetActive(false);
        }
    }
}
