using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private GameObject otherPlayer;
    private Vector2 force = new Vector2(1, 0);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.transform.parent.name == "PlayerObjectOne")
        {
            otherPlayer = GameObject.Find("PlayerObjectTwo");
            if (collision.collider.name == "PlayerObjectOne")
            {

            }
            else if (collision.collider.name == "PlayerObjectTwo")
            {
                otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(transform.forward * 5, ForceMode2D.Impulse);
            }
            
        }
        else
        {
            otherPlayer = GameObject.Find("PlayerObjectOne");
        }
        
    }
}
