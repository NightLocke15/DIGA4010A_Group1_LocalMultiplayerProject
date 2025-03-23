using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Knockback : MonoBehaviour
{
    [SerializeField] private GameObject otherPlayer;
    private Vector2 force = new Vector2(20, 0);
    public float knockBackSpeed = 5;
    [SerializeField] private float waitPeriodOne;
    [SerializeField] private float waitPeriodTwo;
    [SerializeField] private bool knockedOne;
    [SerializeField] private bool knockedTwo;

    private void Update()
    {
        if (knockedOne == true)
        {
            waitPeriodOne += Time.deltaTime;
        }

        if (waitPeriodOne >= 0.1f)
        {
            knockedOne = false;
            GameObject.Find("PlayerObjectOne").transform.GetChild(0).GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            waitPeriodOne = 0;
        }

        if (knockedTwo == true)
        {
            waitPeriodTwo += Time.deltaTime;
        }

        if (waitPeriodTwo >= 0.1f)
        {
            knockedTwo = false;
            GameObject.Find("PlayerObjectTwo").transform.GetChild(0).GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            waitPeriodTwo = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        Title: How to create knockback in Unity
        Author: Sunny Valley Studio
        Date: 29 Jun 2022
        Availability: https://www.youtube.com/watch?v=RXhTD8YZnY4
        Usage: How to add knockback and stop it after a time.
        */
        if (this.gameObject.transform.parent.name == "PlayerObjectOne")
        {
            otherPlayer = GameObject.Find("PlayerObjectTwo");
            if (collision.collider.transform.parent.name == "PlayerObjectOne")
            {

            }
            else if (collision.collider.transform.parent.name == "PlayerObjectTwo")
            {
                
                //Debug.Log("PlayerOne: " + this.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude);
                if (otherPlayer.transform.GetChild(0).position.y - 0.5f > this.transform.position.y + 0.5f)
                {
                    otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(otherPlayer.transform.up * knockBackSpeed, ForceMode2D.Impulse);
                }
                else if (otherPlayer.transform.GetChild(0).position.x > this.transform.position.x)
                {
                    otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(otherPlayer.transform.right * knockBackSpeed, ForceMode2D.Impulse);
                }
                else if (otherPlayer.transform.GetChild(0).position.x < this.transform.position.x)
                {
                    otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(-otherPlayer.transform.right * knockBackSpeed, ForceMode2D.Impulse);
                }
                
                knockedTwo = true;

            }
            
        }
        else if (this.gameObject.transform.parent.name == "PlayerObjectTwo")
        {
            otherPlayer = GameObject.Find("PlayerObjectOne");
            if (collision.collider.transform.parent.name == "PlayerObjectOne")
            {
                //Debug.Log("PlayerTwo: " + this.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude);
                if (otherPlayer.transform.GetChild(0).position.y - 0.5f > this.transform.position.y + 0.5f)
                {
                    otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(otherPlayer.transform.up * knockBackSpeed, ForceMode2D.Impulse);
                }
                else if (otherPlayer.transform.GetChild(0).position.x > this.transform.position.x)
                {
                    otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(otherPlayer.transform.right * knockBackSpeed, ForceMode2D.Impulse);
                }
                else if (otherPlayer.transform.GetChild(0).position.x < this.transform.position.x)
                {
                    otherPlayer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(-otherPlayer.transform.right * knockBackSpeed, ForceMode2D.Impulse);
                }
                knockedOne = true;
            }
            else if (collision.collider.transform.parent.name == "PlayerObjectTwo")
            {
                
            }
        }
        
    }
}
