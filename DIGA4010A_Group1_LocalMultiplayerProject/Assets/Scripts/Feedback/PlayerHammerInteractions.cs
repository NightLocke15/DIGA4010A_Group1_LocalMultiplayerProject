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
                    collision.collider.transform.parent.GetComponent<PlayerInformationHandler>().playerHealth.value -= 5;
                    Debug.Log("Hit ENemy");
                }
                else { }
            }
        }
               
    }
}
