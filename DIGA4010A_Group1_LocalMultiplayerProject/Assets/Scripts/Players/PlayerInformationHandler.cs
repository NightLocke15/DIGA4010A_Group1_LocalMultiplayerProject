using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInformationHandler : MonoBehaviour
{

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
    //https://discussions.unity.com/t/change-game-objects-name-when-in-runtime/443963/5 change name in code

    public Slider playerHealth;
    [SerializeField] private GameObject otherPlayer;
    private float frozenTime;
    [SerializeField] private bool frozenTimeBool;
    public bool startGame;

    public bool playerLost = false;

    private RoundsUI roundsUIScript;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (GameObject.Find("PlayerObjectOne") == null)
        {
            this.gameObject.name = "PlayerObjectOne";
            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            this.gameObject.name = "PlayerObjectTwo";
            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }

        playerHealth = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Slider>();
        playerHealth.value = 100;
    }

    private void Update()
    {
        if (playerHealth.value <= 0)
        {
            playerLost = true;
            if (this.gameObject.name == "PlayerObjectOne")
            {
                roundsUIScript = GameObject.Find("Rounds Won").GetComponent<RoundsUI>();
                roundsUIScript.playerTwoScore = true;
                //this.gameObject.transform.GetChild(0).position = new Vector3(-6, 3);
                //otherPlayer = GameObject.Find("PlayerObjectTwo");
                //otherPlayer.transform.GetChild(0).position = new Vector3(6, 3);
            }
            else if (this.gameObject.name == "PlayerObjectTwo")
            {
                roundsUIScript = GameObject.Find("Rounds Won").GetComponent<RoundsUI>();
                roundsUIScript.playerOneScore = true;
                //this.gameObject.transform.GetChild(0).position = new Vector3(6, 3);
                //otherPlayer = GameObject.Find("PlayerObjectOne");
                //otherPlayer.transform.GetChild(0).position = new Vector3(-6, 3);
            }

            playerHealth.value += 1;
        }

        //FreezeEffect();
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            startGame = true;
        }
        else if (context.canceled)
        {
            startGame = false;
        }
    }

    //Passive
    private void FreezeEffect()
    {
        if (this.gameObject.name == "PlayerObjectOne")
        {
            otherPlayer = GameObject.Find("PlayerObjectTwo");
        }
        else
        {
            otherPlayer = GameObject.Find("PlayerObjectOne");
        }

        if (frozenTimeBool == true)
        {
            otherPlayer.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = false;
        }
        else if (frozenTimeBool == false)
        {
            otherPlayer.transform.GetChild(0).GetComponent<PlayerCon_Script>().enabled = true;
        }        
    }

    private void HigherKnockBack()
    {

    }

    private void HigherHealth()
    {

    }

    private void FasterMovingWeapon()
    {

    }

    //Active
    private void BoosterRocket()
    {

    }

    private void Dash()
    {

    }

    private void Shield()
    {

    }

    private void ChuckBomb()
    {

    }
}
