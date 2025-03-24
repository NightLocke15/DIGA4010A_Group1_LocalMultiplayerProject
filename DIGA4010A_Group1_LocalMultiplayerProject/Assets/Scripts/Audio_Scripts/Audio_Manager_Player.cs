using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Audio_Manager_Player : MonoBehaviour
{
    [SerializeField] private EventReference landingSound, hitSoundGorilla, hitSoundDog, slideSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LandingSound()
    {
        RuntimeManager.PlayOneShot(landingSound, transform.position);
    }

    public void HitSound()
    {
        if (gameObject.name == "PlayerObjectOne")
        {
            RuntimeManager.PlayOneShot(hitSoundDog, transform.position);
        }

        else
        {
            RuntimeManager.PlayOneShot(hitSoundGorilla, transform.position);
        }
    }

    public void DeathSound()
    {
        
    }

    public void SlideSound()
    {
        RuntimeManager.PlayOneShot(slideSound, transform.position);
    }
}
