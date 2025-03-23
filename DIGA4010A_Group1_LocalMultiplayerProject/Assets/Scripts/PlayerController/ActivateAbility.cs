using UnityEngine;

public class ActivateAbility : MonoBehaviour
{
    [SerializeField] private Transform thePot;
    [SerializeField] private GameObject theBomb;
    [SerializeField] private float forceY;
    [SerializeField] private GameObject Check;
    [SerializeField] private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void ActivateBomb()
    {
        if (Check == null) //Checks if the player has released a bomb
        {
            Check = Instantiate(theBomb, thePot.position, Quaternion.identity); //creates bomb
            Check.GetComponent<BombBehaviour>().activateAbility = this;
            Rigidbody2D rb = Check.GetComponent<Rigidbody2D>(); 
            rb.AddForce(Vector2.up*forceY, ForceMode2D.Impulse);  //Throws the bomb up
        }
     
    }


    public void TestKnockback(Transform point, float speed)
    {
        Vector2 dir = (transform.position - point.position).normalized;
        rb.AddForce(dir * speed, ForceMode2D.Impulse );
        Debug.Log("knockback");
    }
    
}
