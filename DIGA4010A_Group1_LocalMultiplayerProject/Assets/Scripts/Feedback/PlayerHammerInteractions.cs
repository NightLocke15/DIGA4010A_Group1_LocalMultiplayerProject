using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHammerInteractions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(SceneManager.GetActiveScene().name == "StageZero")
        {
            if (collision.collider.tag == "Player")
            {
                if (collision.collider.transform.parent.name != this.gameObject.transform.parent.name)
                {
                    //Collision that effects the other player and makes their health less by a certain amount
                    if (this.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude < 1)
                    {
                        collision.collider.transform.parent.GetComponent<PlayerInformationHandler>().playerHealth.value -= 5;
                    }
                    else if (this.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude >= 1 && this.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude < 5)
                    {
                        collision.collider.transform.parent.GetComponent<PlayerInformationHandler>().playerHealth.value -= 10;
                    }
                    else if (this.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude >= 5)
                    {
                        Debug.Log("critical hit");
                        collision.collider.transform.parent.GetComponent<PlayerInformationHandler>().playerHealth.value -= 20;
                    }
                    
                    Debug.Log("Hit ENemy");
                }
                else { }
            }
        }
               
    }
}
