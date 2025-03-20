using System;
using UnityEngine;
using UnityEngine.Serialization;

public class HammerCollider : MonoBehaviour
{
    [FormerlySerializedAs("IsTouchingEnviroment")] public bool IsTouchingEnviromentHammer = false;
    [SerializeField] private PlayerCon_Script playerScript;
    [SerializeField] private Rigidbody2D hammerRb, playerRB;
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
     Vector2 ContactPos = transform.localPosition;
        if (other.collider.tag == "Enviroment")
        {
            IsTouchingEnviromentHammer = true;
            playerScript.SwitchgravityOff();
            hammerRb.linearVelocity = Vector2.zero;
            transform.localPosition = ContactPos;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Enviroment")
        {
            IsTouchingEnviromentHammer = false;
            playerScript.SwitchgravityOn();
        }
    }
}
