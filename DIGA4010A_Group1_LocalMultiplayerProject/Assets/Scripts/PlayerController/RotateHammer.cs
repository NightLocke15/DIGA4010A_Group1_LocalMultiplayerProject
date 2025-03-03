using UnityEngine;
using UnityEngine.Serialization;

public class RotateHammer : MonoBehaviour
{
   // This script just rotates the hammer so that it always looking to the centre of the Player-char body
    [SerializeField]
    private Transform BodyCentre;
    [SerializeField] private Rigidbody2D hammerHeadRb;

    [SerializeField] private float adjust = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Lookdir = BodyCentre.position - hammerHeadRb.transform.position;
        float angle = Mathf.Atan2(Lookdir.y, Lookdir.x) * Mathf.Rad2Deg-adjust;
        hammerHeadRb.rotation = angle;
    }
}
