using UnityEngine;

public class StageManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    [SerializeField] private bool start;

    private void Start()
    {
        playerOne = GameObject.Find("PlayerObjectOne");
        playerTwo = GameObject.Find("PlayerObjectTwo");
        start = true;

        
    }

    private void Update()
    {
        if (start == true)
        {
            playerOne.transform.GetChild(0).position = new Vector3(-18, 3);
            playerTwo.transform.GetChild(0).position = new Vector3(18, 3);
            start = false;
        }
    }
}
