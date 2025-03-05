using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoundsUI : MonoBehaviour
{
    public List<Toggle> rounds = new List<Toggle>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RoundWon(new Color32(9, 253, 0, 255));
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            RoundWon(new Color32(253, 0, 62, 255));
        }
    }

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
