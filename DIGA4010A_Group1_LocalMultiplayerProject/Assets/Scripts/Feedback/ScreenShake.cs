using UnityEngine;
using Unity.Cinemachine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private GameObject cameraShake;

    private float time;
    public bool timer;
    public bool shake;

    private bool shakeTwo;


    private GameObject playerOne;
    private GameObject playerTwo;

    

    private void Start()
    {
        playerOne = GameObject.Find("PlayerObjectOne");
        playerTwo = GameObject.Find("PlayerObjectTwo");

        cameraShake.GetComponent<CinemachineBasicMultiChannelPerlin>().enabled = false;
    }

    private void Update()
    {
        if (timer == true)
        {
            time += Time.deltaTime;
            cameraShake.GetComponent<CinemachineBasicMultiChannelPerlin>().enabled = true;
        }

        if (time >= 0.2f)
        {
            timer = false;
            shake = false;
            shakeTwo = false;
            cameraShake.GetComponent<CinemachineBasicMultiChannelPerlin>().enabled = false;
            time = 0;
        }
        
        if (GameObject.Find("PlayerObjectOne") != null)
        {
            if (GameObject.Find("PlayerObjectOne").transform.GetChild(0).position.y >= 0)
            {
                shake = true;
            }
        }

        if (GameObject.Find("PlayerObjectTwo") != null)
        {
            if (GameObject.Find("PlayerObjectTwo").transform.GetChild(0).position.y >= 0)
            {
                shakeTwo = true;
            }
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.parent != null) //Divan added so that the bomb can hopefully exist in the scene
        {
            if (collision.collider.transform.parent.name == "PlayerObjectOne")
            {
                if (shake == true)
                {
                    timer = true;
                } 
            }
            else if (collision.collider.transform.parent.name == "PlayerObjectTwo")
            {
                if (shakeTwo == true)
                {
                    timer = true;
                }
            }
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.collider.transform.parent.name == "PlayerObjectOne")
    //    {
    //        cameraShake.GetComponent<CinemachineBasicMultiChannelPerlin>().enabled = false;
    //    }
    //    else if (collision.collider.transform.parent.name == "PlayerObjectTwo")
    //    {
    //        cameraShake.GetComponent<CinemachineBasicMultiChannelPerlin>().enabled = false;
    //    }
    //}
}
