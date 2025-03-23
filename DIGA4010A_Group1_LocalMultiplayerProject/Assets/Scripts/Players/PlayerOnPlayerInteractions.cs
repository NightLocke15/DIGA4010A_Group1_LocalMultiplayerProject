using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOnPlayerInteractions : MonoBehaviour
{
    [SerializeField] private ParticleSystem slam;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        
            if (collision.collider.tag == "Player")
            {
                if (collision.collider.transform.parent.name != this.gameObject.transform.parent.name)
                {
                    if (this.gameObject.transform.position.y > collision.collider.transform.position.y + 0.5f)
                    {
                    //Collision that effects the other player and makes their health less by a certain amount
                    if (SceneManager.GetActiveScene().name == "StageZero")
                        {
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
                    }
                        
                        

                        collision.collider.transform.GetChild(0).localScale = Vector3.Lerp(collision.collider.transform.GetChild(0).localScale, new Vector3(1.5f, 0.8f, 1), Time.deltaTime*100);
                        slam.Play();

                        GameObject floor = GameObject.Find("Floor");
                        if (floor.GetComponent<ScreenShake>().shake == true)
                        {
                            floor.GetComponent<ScreenShake>().timer = true;
                        }                       

                        Debug.Log("Hit ENemy up top");
                    }
                    else { }
                    
                }
                else { }
            }
        

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.transform.GetChild(0).localScale = new Vector3(1,1,1);
        }            
    }
}
