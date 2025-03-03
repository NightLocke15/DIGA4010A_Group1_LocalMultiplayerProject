using UnityEngine;
using UnityEngine.Serialization;

public class HammerBehaviour : MonoBehaviour
{
   // This script controls the hammer behavior with small things. 
   //NOT MOVEMENT!!!!!!
   //It makes sure the hammer behaves correctly, rotatation
    [SerializeField]
    private Transform BodyCentre;
    [SerializeField] private Rigidbody2D hammerHeadRb;
    [SerializeField] private Rigidbody2D hammerEndRb;
    [SerializeField] private float adjustHead = -90f, adjustEnd = 45f;

    [SerializeField] private float PoleLenght;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //Rotates the hammer head
        Vector2 Lookdir = BodyCentre.position - hammerHeadRb.transform.position;
        float angle = Mathf.Atan2(Lookdir.y, Lookdir.x) * Mathf.Rad2Deg-adjustHead;
        hammerHeadRb.rotation = angle;
        
        //Rotates the hammer end
        Vector2 LookdirEnd = BodyCentre.position - hammerEndRb.transform.position;
        float angleEnd = Mathf.Atan2(LookdirEnd.y, LookdirEnd.x) * Mathf.Rad2Deg-adjustEnd;
        hammerEndRb.rotation = angleEnd;
    }
}
