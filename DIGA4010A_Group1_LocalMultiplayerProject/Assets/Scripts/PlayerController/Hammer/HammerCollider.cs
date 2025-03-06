using System;
using UnityEngine;

public class HammerCollider : MonoBehaviour
{
    public bool IsTouchingEnviroment = false;
    [SerializeField] private PlayerCon_Script playerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enviroment")
        {
            IsTouchingEnviroment = true;
           // playerScript.ManageGravityScale(playerScript.hammerHeadRb, playerScript.playerBodyRb);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Enviroment")
        {
            IsTouchingEnviroment = false;
        }
    }
}
