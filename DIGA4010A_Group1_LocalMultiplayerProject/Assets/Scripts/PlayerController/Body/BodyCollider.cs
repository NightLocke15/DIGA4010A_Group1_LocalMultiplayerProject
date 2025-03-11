using UnityEngine;
using UnityEngine.Serialization;

public class BodyCollider : MonoBehaviour
{
       [FormerlySerializedAs("IsTouchingEnviroment")] public bool IsTouchingEnviromentPlayer = false;
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
       
}
