using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool grounded;
    [SerializeField] private Audio_Manager_Player audio_Manager_Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enviroment")
        {
            grounded = true;
            audio_Manager_Player.LandingSound();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enviroment")
        {
            grounded = false;
        }
    }
}
