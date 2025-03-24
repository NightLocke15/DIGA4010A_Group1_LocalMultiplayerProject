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

    #region Character Sprites
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private SpriteRenderer leftArm;
    [SerializeField] private SpriteRenderer rightArm;
    [SerializeField] private SpriteRenderer pot;

    [SerializeField] private SpriteRenderer bodyFlash;
    [SerializeField] private SpriteRenderer leftArmFlash;
    [SerializeField] private SpriteRenderer rightArmFlash;
    [SerializeField] private SpriteRenderer potFlash;

    [SerializeField] private Sprite deltonBody;
    [SerializeField] private Sprite deltonLeftArm;
    [SerializeField] private Sprite deltonRightArm;
    [SerializeField] private Sprite deltonPot;

    [SerializeField] private Sprite gaspionBody;
    [SerializeField] private Sprite gaspionLeftArm;
    [SerializeField] private Sprite gaspionRightArm;
    [SerializeField] private Sprite gaspionPot;
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
    //[SerializeField] private Audio_Manager_Player audio_Manager_Player;

    [SerializeField] private ActivateAbility activateAbility;



    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        /*
        Title: How to Add Health Bar to Players in Unity!
        Author: Kory Code
        Date: 13 March 2025
        Availability: https://www.youtube.com/watch?v=YJW3TLmckqk
        Usage: How to add health bars to the players
        */

        //Accessing the health slider on the player
        playerHealth = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Slider>();
        playerHealth.value = playerHealth.maxValue;

        /*
        Title: Change Game Object�s name when in runtime
        Author: Marrrk
        Date: 12 March 2025
        Availability: https://discussions.unity.com/t/change-game-objects-name-when-in-runtime/443963/5
        Usage: How to change the name of an object in code
        */
        //Change the name of the prefab to the relevant player name (one or two) when the prefabs are instantiated in, also change the sprites to the right ones, changing the
        //health bar colours and the trail renderer colours
        if (GameObject.Find("PlayerObjectOne") == null)
        {
            this.gameObject.name = "PlayerObjectOne"; 
            this.transform.GetChild(0).gameObject.layer = 6;
            this.transform.GetChild(1).gameObject.layer = 3;
            //this.transform.GetChild(1).GetComponent<BoxCollider2D>().includeLayers = 0;
            body.sprite = deltonBody;
            leftArm.sprite = deltonLeftArm;
            rightArm.sprite = deltonRightArm;
            pot.sprite = deltonPot;

            bodyFlash.sprite = deltonBody;
            leftArmFlash.sprite = deltonLeftArm;
            rightArmFlash.sprite = deltonRightArm;
            potFlash.sprite = deltonPot;

            this.gameObject.transform.position = new Vector3(-18, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            playerHealth.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().color = new Color32(254, 134, 0, 255);
            this.transform.GetChild(1).GetComponent<TrailRenderer>().startColor = new Color32(254, 134, 0, 255);
            this.transform.GetChild(1).GetComponent<TrailRenderer>().endColor = new Color32(254, 134, 0, 255);
        }
        else
        {
            this.gameObject.name = "PlayerObjectTwo";
            this.transform.GetChild(0).gameObject.layer = 9;
            this.transform.GetChild(1).gameObject.layer = 8;
            //this.transform.GetChild(1).GetComponent<BoxCollider2D>().includeLayers = 3 | 6;
            body.sprite = gaspionBody;
            leftArm.sprite = gaspionLeftArm;
            rightArm.sprite = gaspionRightArm;
            pot.sprite = gaspionPot;

            bodyFlash.sprite = gaspionBody;
            leftArmFlash.sprite = gaspionLeftArm;
            rightArmFlash.sprite = gaspionRightArm;
            potFlash.sprite = gaspionPot;

            this.gameObject.transform.position = new Vector3(18, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            playerHealth.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().color = new Color32(0, 89, 255, 255);
            this.transform.GetChild(1).GetComponent<TrailRenderer>().startColor = new Color32(0, 89, 255, 255);
            this.transform.GetChild(1).GetComponent<TrailRenderer>().endColor = new Color32(0, 89, 255, 255);
        }

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

        /* 
        Title: Dust Effect when Running & Jumping in Unity [Particle Effect]
        Author: Press Start
        Date: 16 March 2025
        Availability: https://www.youtube.com/watch?v=1CXVbCbqKyg
        Usage: adding dust particles when sliding
        */
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

        //Having the trail only appear when the player moves the weapon
        if (input == true)
        {
            weaponTrail.emitting = true;
        }
        else
        {
            weaponTrail.emitting = false;
        }

        //Upgrades
        if (higherKnockback == true)
        {
            HigherKnockBack();
        }

        if (fasterMovingWeapon == true)
        {
            FasterMovingWeapon();
        }

        if (higherHealth == true)
        {
            HigherHealth();
        }

        if (chuckBomb == true)
        {
            ChuckBomb();
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
    private void FreezeEffect() //Not implemented yet
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
        //Adding to the knockback speed
        Knockback knockBackSpeed = this.gameObject.transform.GetChild(1).GetComponent<Knockback>();
        knockBackSpeed.knockBackSpeed = 15;
    }

    private void HigherHealth()
    {
        //Adding to the max health
        playerHealth.maxValue = 120;
    }

    private void FasterMovingWeapon()
    {
        //Having the weapon move faster
        PlayerCon_Script playerCon = this.gameObject.transform.GetChild(0).GetComponent<PlayerCon_Script>();
        playerCon.moveSpeed = 7;
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
        //This was not necessary as of yet
    }
}
