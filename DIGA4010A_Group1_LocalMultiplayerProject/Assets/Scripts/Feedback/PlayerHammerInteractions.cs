using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHammerInteractions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        {
            if (collision.collider.tag == "Player")
            {
                if (collision.collider.transform.parent.name != this.gameObject.transform.parent.name)
                {
                    if (SceneManager.GetActiveScene().name == "StageZero")
                    {
                        //Collision that effects the other player and makes their health less by a certain amount
                        if (this.gameObject.transform.parent.GetChild(0).GetComponent<PlayerCon_Script>().currentSpeed < 15)
                        {
                            collision.collider.transform.parent.GetComponent<PlayerInformationHandler>().playerHealth.value -= 5;
                        }
                        else if (this.gameObject.transform.parent.GetChild(0).GetComponent<PlayerCon_Script>().currentSpeed >= 15 && this.gameObject.GetComponent<PlayerCon_Script>().currentSpeed < 25)
                        {
                            collision.collider.transform.parent.GetComponent<PlayerInformationHandler>().playerHealth.value -= 10;
                        }
                        else if (this.gameObject.transform.parent.GetChild(0).GetComponent<PlayerCon_Script>().currentSpeed >= 25)
                        {
                            Debug.Log("critical hit");
                            collision.collider.transform.parent.GetComponent<PlayerInformationHandler>().playerHealth.value -= 20;
                        }

                        collision.collider.transform.GetChild(4).GetComponent<ParticleSystem>().Play();
                        Debug.Log("Hit ENemy");
                    }

                    collision.collider.transform.GetChild(4).GetComponent<ParticleSystem>().Play();
                    collision.collider.transform.GetChild(0).GetComponent<HitFlash>().flash = true;
                }
                else { }
            }
        }
               
    }
}
