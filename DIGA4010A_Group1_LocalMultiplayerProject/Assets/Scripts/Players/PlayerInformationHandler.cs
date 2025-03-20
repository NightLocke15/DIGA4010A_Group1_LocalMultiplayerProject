using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInformationHandler : MonoBehaviour
{
    /* 1.
        Title:
        Author:
        Date:
        Code Version:
        Availability: https://www.youtube.com/watch?v=YJW3TLmckqk
        Usage: How to add health bars to the players
     */

    /* 2.
        Title:
        Author:
        Date:
        Code Version:
        Availability: https://discussions.unity.com/t/change-game-objects-name-when-in-runtime/443963/5
        Usage: How to change the name of an object in code
     */

    /* 3.
        Title:
        Author:
        Date:
        Code Version:
        Availability: https://www.youtube.com/watch?v=1CXVbCbqKyg
        Usage: adding dust particles when sliding
     */

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

    public Slider playerHealth;
    [SerializeField] private GameObject otherPlayer;
    private float frozenTime;
    [SerializeField] private bool frozenTimeBool;
    public bool startGame;

    public bool playerLost = false;

    private RoundsUI roundsUIScript;

    [SerializeField] private ParticleSystem dustParticles;
    [SerializeField] private TrailRenderer weaponTrail;
    public bool input;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        //Change the name of the prefab to the relevant player name (one or two) when the prefabs are instantiated in.
        if (GameObject.Find("PlayerObjectOne") == null)
        {
            this.gameObject.name = "PlayerObjectOne"; //2 in references
            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            this.gameObject.transform.position = new Vector3(-18, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
        else
        {
            this.gameObject.name = "PlayerObjectTwo";
            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
            this.gameObject.transform.position = new Vector3(18, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

        //Accessing the health slider on the player
        playerHealth = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Slider>(); //1. in references
        playerHealth.value = playerHealth.maxValue;

        dustParticles.Pause();

    }

    private void Update()
    {
        if (playerHealth.value <= 0)
        {
            //Opening the relevant UI page connected to the losing player so they can choose their upgrade
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

            //Adding one to the player health after losing so the conditions attached to 0 health doesn't block the UI button functionality in the RoundsUI script
            playerHealth.value += 1;
        }

        //FreezeEffect();

        //3. reference
        //Checking if the player is grounded
        if (this.gameObject.transform.GetChild(0).GetComponent<GroundCheck>().grounded == true)
        {
            //Checking the direction the player is moving in and playing dust particles in the opposite direction
            if (this.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>().linearVelocityX > 5)
            {
                dustParticles.transform.localScale = new Vector3(1, 1, 1);
                var emision = dustParticles.emission;
                emision.rateOverTime = 150;
                dustParticles.Play();
            }
            else if (this.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>().linearVelocityX < -5)
            {
                dustParticles.transform.localScale = new Vector3(-1, 1, 1);
                var emision = dustParticles.emission;
                emision.rateOverTime = 150;
                dustParticles.Play();
            }
            else
            {
                var emision = dustParticles.emission;
                emision.rateOverTime = 0;
            }
        }
        else
        {
            //Stopping emmision when the player is in the air
            var emision = dustParticles.emission;
            emision.rateOverTime = 0;
        }

        if (input == true)
        {
            weaponTrail.emitting = true;
        }
        else
        {
            weaponTrail.emitting = false;
        }
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        //Getting out of the lobby/waiting room
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
        Knockback knockBackSpeed = this.gameObject.transform.GetChild(1).GetComponent<Knockback>();
        knockBackSpeed.knockBackSpeed = 120;
    }

    private void HigherHealth()
    {
        playerHealth.maxValue = 120;
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
