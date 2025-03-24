using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Audio_Bomb : MonoBehaviour
{
    [SerializeField] private EventReference bombExplosion;

    [SerializeField] private EventReference bombTing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ExplodeSound()
    {
        RuntimeManager.PlayOneShot(bombExplosion, transform.position);
    }

    public void TingSound()
    {
        RuntimeManager.PlayOneShot(bombTing, transform.position);
    }
}
