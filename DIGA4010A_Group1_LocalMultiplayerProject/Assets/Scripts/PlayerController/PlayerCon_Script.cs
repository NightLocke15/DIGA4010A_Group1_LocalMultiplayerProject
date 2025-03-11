using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;

public class PlayerCon_Script : MonoBehaviour
{
   //This script Controls all the movement for the player(Both hammer and body)
   [SerializeField] private float outerRadius; //How far the hammer can reach
   [SerializeField] private float innerRadius; //the deadzone where the arms can't go at centre of body

   [SerializeField] private Transform playerBody;
   private Vector2 directionLeft, directionRight;
   private Vector2 boostDirection;
   private Vector2 finalDirection;

   [SerializeField]
   private Rigidbody2D hammerHeadRb;
   [SerializeField] private Rigidbody2D playerBodyRb;
   // [SerializeField] private float moveSpeedx, defaultx, moveSpeedy, defaulty, speedAdjuster;
   [SerializeField] private float moveSpeed = 5f;
   [SerializeField] private HammerCollider hammerColScript;

   [SerializeField] private float gravity = 9.81f;
   [FormerlySerializedAs("HasInput")] [SerializeField] private bool HasLeftInput = false, HasRightInput = false;

   [SerializeField] private float speedBarrier, currentSpeed, force;
   
   [SerializeField]
   private Vector2 prevPos, currentPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerBodyRb.gravityScale = gravity;
       prevPos = playerBody.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
       
        // if (!hammerColScript.IsTouchingEnviromentHammer)
        // {
        //     //  hammerHeadRb.transform.parent = playerBody;
        //     ApplyMovement(hammerHeadRb.transform,playerBody, 1f);
        // }
        // else
        // {
        //     // playerBody.transform.parent = hammerHeadRb.transform;
        //     ApplyMovement(playerBody.transform, hammerHeadRb.transform,-1f);
        // }
        
        // if (HasLeftInput || HasRightInput)
        // {
        //     if (!hammerColScript.IsTouchingEnviromentHammer)
        //     {
        //         //  hammerHeadRb.transform.parent = playerBody;
        //         ApplyMovement(hammerHeadRb.transform,playerBody, 1f);
        //     }
        //     else
        //     {
        //         // playerBody.transform.parent = hammerHeadRb.transform;
        //         ApplyMovement(playerBody.transform, hammerHeadRb.transform,-1f);
        //     }
        // }
        //
        // else
        // {
        //     hammerHeadRb.linearVelocity = Vector2.zero;
        // }
        //
       
       
        
    }

    private void FixedUpdate()
    {
        if (!hammerColScript.IsTouchingEnviromentHammer)
        {
            //  hammerHeadRb.transform.parent = playerBody;
            ApplyMovement(hammerHeadRb.transform,playerBody, 1f);
        }
        else
        {
            // playerBody.transform.parent = hammerHeadRb.transform;
            ApplyMovement(playerBody.transform, hammerHeadRb.transform,-1f);
        }
    }

    private void ApplyMovement(Transform moveThis,Transform AnchorPoint, float inverseDirection)
    {
        currentPos = playerBody.localPosition;
        Vector2 anchorPos = Vector2.zero;
        Vector2 AdjustIP = new Vector2(moveThis.localPosition.x- AnchorPoint.localPosition.x, moveThis.localPosition.y- AnchorPoint.localPosition.y);
        Vector2 initialPos = new Vector2(anchorPos.x+ AdjustIP.x, anchorPos.y + AdjustIP.y);
        Vector2 direction = new Vector2(directionLeft.x + directionRight.x, directionLeft.y + directionRight.y); 
        Vector2 Movement = (new Vector2(direction.x * moveSpeed, direction.y * moveSpeed)*Time.deltaTime) * inverseDirection;
        float speed = 0;
        speed = Vector2.Distance(currentPos, prevPos) / Time.deltaTime;
        float Result = 0;
        Result = speed;
        Debug.Log(Result);
        
      //  Debug.Log(Xspeed + Yspeed);
        
       // Debug.Log(Yspeed);

        if (moveThis == hammerHeadRb.transform)
        {
            Vector2 allowedPos = new Vector2(initialPos.x + Movement.x, initialPos.y + Movement.y);
            //float mag = Vector2.Distance(allowedPos, anchorPos);
            Vector2 mag = new Vector2(allowedPos.x - anchorPos.x, allowedPos.y- anchorPos.y);
            Vector2 restrictPos = mag.normalized * Mathf.Clamp(mag.magnitude, innerRadius, outerRadius);
            Vector2 finalPos = new Vector2(restrictPos.x+ AnchorPoint.localPosition.x, restrictPos.y+ AnchorPoint.localPosition.y);
        
            moveThis.localPosition = Vector2.MoveTowards(moveThis.localPosition, finalPos, 1);
        }
        
        else if (moveThis == playerBody)
        {
            if (Result <= speedBarrier)
            {
                Vector2 allowedPos = new Vector2(initialPos.x + Movement.x, initialPos.y + Movement.y);
                //float mag = Vector2.Distance(allowedPos, anchorPos);
                Vector2 mag = new Vector2(allowedPos.x - anchorPos.x, allowedPos.y- anchorPos.y);
                Vector2 restrictPos = mag.normalized * Mathf.Clamp(mag.magnitude, innerRadius, outerRadius);
                Vector2 finalPos = new Vector2(restrictPos.x+ AnchorPoint.localPosition.x, restrictPos.y+ AnchorPoint.localPosition.y);
        
                moveThis.localPosition = Vector2.MoveTowards(moveThis.localPosition, finalPos, 1);
            }
            
            else
            {
               float Addforce = force * Result;
               playerBodyRb.AddForce(Movement.normalized * Addforce, ForceMode2D.Impulse);
               hammerColScript.IsTouchingEnviromentHammer = false;
            }
           
        }
        
        prevPos = currentPos;
       
        //Moves the hammer head between two the two radius 
        // Vector2 AnchorPos = new Vector2(AnchorPoint.position.x, AnchorPoint.position.y); // This is the postition the player can move around. Either the player-body or the hammer head
        // Vector2 Movement = (new Vector2(direction.x * moveSpeedx, direction.y * moveSpeedy)*Time.fixedDeltaTime) * inverseDirection; //This is the direction in which we want to go
        // Vector2 initialPos = new Vector2(moveThis.position.x, moveThis.position.y); //This is the current position of the gameobject we want to move
        // Vector2 allowedPos = new Vector2(initialPos.x + Movement.x, initialPos.y + Movement.y); //We add the direction to the space we currently are 
        // float offset = Vector2.Distance(AnchorPos, allowedPos); //Get the distance between the anchor point and the allowedPos
        // Vector2 requiredDirection = new Vector2(allowedPos.x - AnchorPos.x, allowedPos.y - AnchorPos.y); //Get the direction to the new allowedPos
        // Vector2 test =  (requiredDirection.normalized) * Mathf.Clamp(offset, innerRadius, outerRadius);//Now we move the hammer head after we have clamped the lenght of the target postion between the two radius.
        // moveThis.position = test;
        // Debug.Log(offset+ ":Offset");
        // Debug.Log(requiredDirection.magnitude + ":Magnitude");

    }

    public void SwitchgravityOn()
    {
        playerBodyRb.gravityScale = gravity;
    }

    public void SwitchgravityOff()
    {
        playerBodyRb.gravityScale = 0f;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerBody.position, outerRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(playerBody.position, innerRadius);
    }

    public void LeftInputMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 PlayerInput = context.ReadValue<Vector2>();
            directionLeft.x = PlayerInput.x;
            directionLeft.y = PlayerInput.y;
            HasLeftInput = true;
        }
        else
        {
            HasLeftInput = false;
            directionLeft = Vector2.zero;
        }
    }

    public void RightInputMovement(InputAction.CallbackContext context)
    {
            if (context.performed)
            {
                Vector2 PlayerInput = context.ReadValue<Vector2>();
                directionRight.x = PlayerInput.x;
                directionRight.y = PlayerInput.y;
                HasRightInput = true;
            }
            else
            {
                HasRightInput = false;
                directionRight = Vector2.zero;
            }
         //   Vector2 PlayerInput = context.ReadValue<Vector2>();
        //     if (PlayerInput.x < 0)
        //     {
        //         moveSpeedx = -defaultx * (PlayerInput.x-speedAdjuster);
        //     }
        //     else
        //     {
        //         moveSpeedx = defaultx * (PlayerInput.x + speedAdjuster);
        //     }
        //     
        //     if (PlayerInput.y < 0)
        //     {
        //         moveSpeedy = -defaulty * (PlayerInput.y-speedAdjuster);
        //     }
        //     else
        //     {
        //         moveSpeedy = defaulty * (PlayerInput.y+speedAdjuster);
        //     }
        //     // Debug.Log(PlayerInput.x + PlayerInput.y);
        //     // moveSpeedx = moveSpeedx * (PlayerInput.x+1);
        //     // moveSpeedy = moveSpeedy * (PlayerInput.y+1);
        // }
        // else
        // {
        //    moveSpeedx = defaultx;
        //    moveSpeedy = defaulty;
        // }
    }
}
