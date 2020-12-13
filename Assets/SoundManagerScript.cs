using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip shotSound, soundtrack,bullethit, Attack,death, reload,noammo;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {   
        shotSound = Resources.Load<AudioClip>("Small_Gun_Shot");
        soundtrack = Resources.Load<AudioClip>("darkness");
        bullethit= Resources.Load<AudioClip>("bulletHit");
        Attack = Resources.Load<AudioClip>("spider");
        noammo = Resources.Load<AudioClip>("noammo");
        reload = Resources.Load<AudioClip>("reload");
        death = Resources.Load<AudioClip>("death");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Small_Gun_Shot":
                audioSrc.PlayOneShot(shotSound);
                break;

            case "bulletHit":
                audioSrc.PlayOneShot(bullethit);
                break;
            case "spider":
                audioSrc.PlayOneShot(Attack);
                break;
            case "death":
                audioSrc.PlayOneShot(death);
                break;

               case "noammo":
                audioSrc.PlayOneShot(noammo);
                break;

                case "reload":
                audioSrc.PlayOneShot(reload);
                break;
        }
    }
}


// audioSrc.PlayOneShot(soundtrack);