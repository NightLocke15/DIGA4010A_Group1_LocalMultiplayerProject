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
   private Vector2 finalDirection;

   [SerializeField] private Rigidbody2D hammerHeadRb;
   [SerializeField] private Rigidbody2D hammerEndRb;
   [SerializeField] private float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the hammer head between two the two radius 
        Vector2 Movement = direction * moveSpeed * Time.deltaTime; //This is the direction in which we want to go
        Vector2 initialPos = new Vector2(hammerHeadRb.transform.localPosition.x, hammerHeadRb.transform.localPosition.y); //This is where we are
        Vector2 allowedPos = Movement + initialPos; //We put our direction and where we are together to get the target position of where we want to move to
        
        allowedPos = Vector2.MoveTowards(hammerHeadRb.transform.localPosition, allowedPos, moveSpeed * Time.deltaTime); // This moves the target position to the correct spot
        hammerHeadRb.transform.localPosition = allowedPos.normalized * Mathf.Clamp(allowedPos.magnitude, innerRadius, outerRadius);//Now we move the hammer head after we have clamped the lenght of the target postion between the two radius.

        Vector2 InverseMovement = new Vector2(Movement.x*-1f, Movement.y*-1f);
        hammerEndRb.transform.Translate(InverseMovement);
    }

  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerBody.position, outerRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(playerBody.position, innerRadius);
    }

    public void WaarIsJy(InputAction.CallbackContext context)
    {
        Debug.Log("WaarIsJy");
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
}
