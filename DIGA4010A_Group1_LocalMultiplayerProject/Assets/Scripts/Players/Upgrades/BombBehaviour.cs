using System;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
   [SerializeField] private float radius, timeToExplode, timeToSwitchOnCollider;
   [SerializeField] private int bouncesTillExplode;
   [SerializeField] private bool timedDetonation, bouncedDetonation, explodeOnPlayer; // timed = bomb is on a timer to explode, bounced = bomb has x-amount(bouncesTillExplode) before it explodes, explodeOnPlayer = explodes on collision with a player
   [SerializeField] private float StartTime;
   public ActivateAbility activateAbility;
   [SerializeField] private float speed;

   private Vector2 currentPos, prevPos;

   [SerializeField] private Audio_Bomb audioBomb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartTime = Time.time; //Gets the time stamp upon spawning into the game
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timedDetonation)
        {
            Countdown();
        }
        
        SwitchOnCollider();
    }

    private void FixedUpdate()
    {
        currentPos = transform.position;
        speed = Vector2.Distance(currentPos, prevPos) / Time.deltaTime;
        prevPos = currentPos;
    }

    private void SwitchOnCollider()
    {
        if (Time.time - StartTime > timeToSwitchOnCollider)
        {
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        
    }
    
    private void Countdown()
    {
        if (Time.time - StartTime > timeToExplode)
        {
          
            BombGoesBoom();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (explodeOnPlayer && other.gameObject.tag == "Player")
        {
            Debug.Log("Bombed");
            other.collider.transform.parent.GetComponent<PlayerInformationHandler>().playerHealth.value -= 30;
            activateAbility.TestKnockback(transform, speed);
            BombGoesBoom();
        }

        if (bouncedDetonation)
        {
            bouncesTillExplode -= 1;

            if (bouncesTillExplode <= 0)
            {
                BombGoesBoom();
            }

            else
            {
                audioBomb.TingSound();
            }
        }
        
       
    }

    private void BombGoesBoom()
    {
        audioBomb.ExplodeSound();
        Destroy(gameObject);
    }
}
