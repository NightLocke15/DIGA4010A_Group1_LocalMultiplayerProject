using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoHolder : MonoBehaviour
{
    //https://www.youtube.com/watch?v=YJW3TLmckqk for how to add health bar to players

    [SerializeField] private Slider playerHealth;

    private void Start()
    {
        playerHealth.value = 100;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerHealth.value -= 5;
        }
    }
}
