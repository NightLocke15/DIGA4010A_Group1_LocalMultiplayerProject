using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private RoundsUI roundsUIScript;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject winTextOne;
    [SerializeField] private GameObject winTextTwo;
    [SerializeField] private GameObject roundsScreen;
    [SerializeField] private GameObject upgradeScreen;
    [SerializeField] private Button firtsButton;

    private void Start()
    {
        winScreen.SetActive(false);
    }

    private void Update()
    {
        if (roundsUIScript.playerOneWins >= 2)
        {
            winScreen.SetActive(true);
            winTextOne.SetActive(true);
            winTextTwo.SetActive(false);
            roundsScreen.SetActive(false);
            upgradeScreen.SetActive(false);
            firtsButton.Select();
        }
        else if (roundsUIScript.playerTwoWins >= 2)
        {
            winScreen.SetActive(true);
            winTextOne.SetActive(false);
            winTextTwo.SetActive(true);
            roundsScreen.SetActive(false);
            upgradeScreen.SetActive(false);
            firtsButton.Select();
        }
    }
}
