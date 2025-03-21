using System;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
   [SerializeField] private float radius, timeToExplode;
   [SerializeField] private int bouncesTillExplode;
   [SerializeField] private bool timedDetonation, bouncedDetonation, explodeOnPlayer;
   [SerializeField] private float StartTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timedDetonation)
        {
            Countdown();
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
        if (bouncedDetonation)
        {
            bouncesTillExplode -= 1;

            if (bouncesTillExplode <= 0)
            {
                BombGoesBoom();
            }
        }
    }

    private void BombGoesBoom()
    {
        Debug.Log("Boom");
        Destroy(gameObject);
    }
}
