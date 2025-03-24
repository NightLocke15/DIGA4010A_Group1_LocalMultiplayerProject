using UnityEngine;
using System.Collections.Generic;



public class FlipSprite : MonoBehaviour
{
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();

    private void Update()
    {
        //Flip the sprite when they move in a certain direction
        if (this.transform.parent.GetComponent<Rigidbody2D>().linearVelocity.x > 0)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);

            //for (int i = 0; i < sprites.Count; i++)
            //{
            //    sprites[i].flipX = false;
            //}
        }
        else if (this.transform.parent.GetComponent<Rigidbody2D>().linearVelocity.x < 0)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);

            //for (int i = 0; i < sprites.Count; i++)
            //{
            //    sprites[i].flipX = true;
            //}
        }
    }
}
