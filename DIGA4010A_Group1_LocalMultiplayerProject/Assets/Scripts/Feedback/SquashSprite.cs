using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SquashSprite : MonoBehaviour
{
	// https://github.com/keenanwoodall/SimpleSquashAndStretchMovement2D/blob/master/Assets/_SnSMovement/Code/Components/General/Transform/ScaleByVelocity.cs

	[SerializeField] private Rigidbody2D rigidBody;
	private Vector2 ogScale;

    //all the struggles

    //private void Start()
    //{
    //    //ogScale = new Vector3(1,1,1);
    //}

    //private void Update()
    //{
    //    if (rigidBody.linearVelocity.magnitude > 0.1f)
    //    {
    //        Vector2 direction = rigidBody.linearVelocity.normalized;

    //        float x = 1 + Mathf.Clamp(rigidBody.linearVelocity.magnitude * 1.5f, 0, 1.5f);
    //        float y = Mathf.Clamp(1 / (rigidBody.linearVelocity.magnitude * 0.5f), 0.5f, 1);

    //        if (direction.x < 0)
    //        {
    //            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(x * direction.x * -1, y * direction.y, 1), Time.deltaTime * 3);
    //        }
    //        else if (direction.y < 0)
    //        {
    //            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(x * direction.x, y * direction.y * -1, 1), Time.deltaTime * 3);
    //        }
    //        else if (direction.x < 0 && direction.y < 0)
    //        {
    //            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(x * direction.x * -1, y * direction.y * -1, 1), Time.deltaTime * 3);
    //        }
    //        else
    //        {
    //            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(x * direction.x , y * direction.y , 1), Time.deltaTime * 3);
    //        }
    //    }
    //    else
    //    {
    //        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 3);
    //    }

    //    //if (rigidBody.linearVelocity.magnitude > 0)
    //    //{
    //    //    transform.localScale = ogScale * rigidBody.linearVelocity.magnitude;
    //    //}



    //    //if (rigidBody.linearVelocityX != 0)
    //    //{
    //    //    transform.localScale = new Vector3(1 + (rigidBody.linearVelocity.magnitude * 0.1f), 1 / (1 + (rigidBody.linearVelocity.magnitude * 0.1f)), 1);
    //    //}

    //    //if (rigidBody.linearVelocityY != 0)
    //    //{

    //    //    transform.localScale = new Vector3(1 / (1 + (rigidBody.linearVelocity.magnitude * 0.1f)), 1 + (rigidBody.linearVelocity.magnitude * 0.1f), 1);
    //    //}
    //}
}
