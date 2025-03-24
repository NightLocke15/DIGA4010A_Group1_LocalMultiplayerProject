using UnityEngine;
using System.Collections;

public class ArmHandller : MonoBehaviour
{
    [SerializeField] private GameObject Hammer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.rotation = Hammer.transform.rotation;
    }
}
