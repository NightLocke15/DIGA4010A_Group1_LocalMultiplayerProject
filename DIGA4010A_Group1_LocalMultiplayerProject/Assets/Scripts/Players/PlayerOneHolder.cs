using UnityEngine;
using UnityEngine.UI;

public class PlayerOneHolder : MonoBehaviour
{
    public bool p1lost = false;

    #region Upgrades
    //Passive
    public bool freezeOnCrit;
    public bool higherKnockback;
    public bool higherHealth;
    public bool fasterMovingWeapon;

    //Active
    public bool boosterRocket;
    public bool dash;
    public bool shield;
    public bool chuckBomb;
    #endregion

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
