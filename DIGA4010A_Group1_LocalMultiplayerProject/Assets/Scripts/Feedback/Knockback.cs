using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private GameObject otherPlayer;
    private Vector2 force = new Vector2(20, 0);
    public float knockBackSpeed = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.transform.parent.name == "PlayerObjectOne")
        {
            otherPlayer = GameObject.Find("PlayerObjectTwo");
            if (collision.collider.transform.parent.name == "PlayerObjectOne")
            {

            }
            else if (collision.collider.transform.parent.name == "PlayerObjectTwo")
            {
                //Debug.Log("PlayerOne: " + this.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude);
                if (otherPlayer.transform.GetChild(0).position.x > this.transform.position.x)
                {
                    otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(otherPlayer.transform.right * knockBackSpeed, ForceMode2D.Impulse);
                }
                else if (otherPlayer.transform.GetChild(0).position.x < this.transform.position.x)
                {
                    otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(-otherPlayer.transform.right * knockBackSpeed, ForceMode2D.Impulse);
                }
                
            }
            
        }
        else if (this.gameObject.transform.parent.name == "PlayerObjectTwo")
        {
            otherPlayer = GameObject.Find("PlayerObjectOne");
            if (collision.collider.transform.parent.name == "PlayerObjectOne")
            {
                //Debug.Log("PlayerTwo: " + this.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude);
                if (otherPlayer.transform.GetChild(0).position.x > this.transform.position.x)
                {
                    otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(otherPlayer.transform.right * knockBackSpeed, ForceMode2D.Impulse);
                }
                else if (otherPlayer.transform.GetChild(0).position.x < this.transform.position.x)
                {
                    otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(-otherPlayer.transform.right * knockBackSpeed, ForceMode2D.Impulse);
                }
            }
            else if (collision.collider.transform.parent.name == "PlayerObjectTwo")
            {
                
            }
        }
        
    }
}
