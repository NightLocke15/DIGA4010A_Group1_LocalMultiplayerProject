using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerCon_Script : MonoBehaviour
{
   //This script Controls all the movement for the player(Both hammer and body)
   [SerializeField] private float outerRadius; //How far the hammer can reach
   [SerializeField] private float innerRadius; //the deadzone where the arms can't go at centre of body

   [SerializeField] private Transform playerBody;
   private Vector2 direction;
   private Vector2 boostDirection;
   private Vector2 finalDirection;

   public Rigidbody2D hammerHeadRb;
   [SerializeField] private Rigidbody2D hammerEndRb;
   public Rigidbody2D playerBodyRb;
   [SerializeField] private float moveSpeedx, defaultx, moveSpeedy, defaulty, speedAdjuster;
   
   [SerializeField] private HammerCollider hammerColScript;

   [SerializeField] private float gravity = 9.81f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!hammerColScript.IsTouchingEnviroment)
        {
          //  hammerHeadRb.transform.parent = playerBody;
            ApplyMovement(hammerHeadRb.transform, 1f);
        }
        else
        {
          // playerBody.transform.parent = hammerHeadRb.transform;
            ApplyMovement(playerBody.transform, -1f);
        }
    }

    private void ApplyMovement(Transform moveThis, float inverseDirection)
    {
        //Moves the hammer head between two the two radius 
        Vector2 Movement = (new Vector2(direction.x * moveSpeedx, direction.y * moveSpeedy) * Time.deltaTime) * inverseDirection; //This is the direction in which we want to go
        Vector2 initialPos = new Vector2(moveThis.localPosition.x, moveThis.localPosition.y); //This is where we are
        Vector2 allowedPos = (Movement) + initialPos; //We put our direction and where we are together to get the target position of where we want to move to
       
        allowedPos = Vector2.MoveTowards(moveThis.localPosition, allowedPos, moveSpeedx * moveSpeedy * Time.deltaTime); // This moves the target position to the correct spot
        moveThis.localPosition = allowedPos.normalized * Mathf.Clamp(allowedPos.magnitude, innerRadius, outerRadius);//Now we move the hammer head after we have clamped the lenght of the target postion between the two radius.

    }

    public void ManageGravityScale(Rigidbody2D AddGravityScale, Rigidbody2D RemoveGravityScale)
    {
        AddGravityScale.linearVelocity = Vector2.zero;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerBody.position, outerRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(playerBody.position, innerRadius);
    }

    public void InputMovement(InputAction.CallbackContext context)
    {
       
        if (context.performed)
        {
            Vector2 PlayerInput = context.ReadValue<Vector2>();
            direction.x = PlayerInput.x;
            direction.y = PlayerInput.y;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    public void Boosting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           
            Vector2 PlayerInput = context.ReadValue<Vector2>();
            if (PlayerInput.x < 0)
            {
                moveSpeedx = -defaultx * (PlayerInput.x-speedAdjuster);
            }
            else
            {
                moveSpeedx = defaultx * (PlayerInput.x + speedAdjuster);
            }
            
            if (PlayerInput.y < 0)
            {
                moveSpeedy = -defaulty * (PlayerInput.y-speedAdjuster);
            }
            else
            {
                moveSpeedy = defaulty * (PlayerInput.y+speedAdjuster);
            }
            // Debug.Log(PlayerInput.x + PlayerInput.y);
            // moveSpeedx = moveSpeedx * (PlayerInput.x+1);
            // moveSpeedy = moveSpeedy * (PlayerInput.y+1);
        }
        else
        {
           moveSpeedx = defaultx;
           moveSpeedy = defaulty;
        }
    }
}
