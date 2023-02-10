using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public enum SFXType
{
    WALK,
    CHANGE,
    RELOAD,
    KNIFE,
    SHOOT,
    DAMAGE,
    BUTTON,
    HIT,
    ENEMY

};


public class AudioManager : MonoBehaviour
{
    public static AudioManager instanceAudioManager;
    
    public AudioSource musica;
    public AudioSource SFX;
    public AudioSource ambiente;
   
    public AudioMixer mixer;

    public AudioClip[] musicaCollection;
    public AudioClip[] sfxCollection;

    public Slider sliderVolMusica;
    public Slider sliderVolSFX;
    public Slider sliderVolAmbiente;

    public bool ReproduccionPatrulla = false;
    public bool ReproduccionChase = false;


    private void Awake()
    {
        instanceAudioManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        mixer.SetFloat("VolMusica",sliderVolMusica.value);
        mixer.SetFloat("VolSFX", sliderVolSFX.value);
        mixer.SetFloat("VolAmbiente", sliderVolAmbiente.value);

    }

    public void PlaySFX(SFXType sfxType)
    {
        switch(sfxType)
        {
            case SFXType.WALK:
                if (!SFX.isPlaying)
                {
                    SFX.PlayOneShot(sfxCollection[0]);
                }
                break;
            case SFXType.CHANGE:
                SFX.PlayOneShot(sfxCollection[1]);
                break;
            case SFXType.RELOAD:
                SFX.PlayOneShot(sfxCollection[2]);
                break;
            case SFXType.KNIFE:
                SFX.PlayOneShot(sfxCollection[3]);
                break;
            case SFXType.SHOOT:
                SFX.PlayOneShot(sfxCollection[4]);
                break;
            case SFXType.DAMAGE:
                SFX.PlayOneShot(sfxCollection[5]);
                break;
            case SFXType.BUTTON:
                SFX.PlayOneShot(sfxCollection[6]);
                break;
            case SFXType.HIT:
                SFX.PlayOneShot(sfxCollection[7]);
                break;
            case SFXType.ENEMY:
                SFX.PlayOneShot(sfxCollection[8]);
                break;

        }
    }

    public void PlayMusic(int musicClip)
    {
        musica.clip = musicaCollection[musicClip];
        if (musicClip == 0 && ReproduccionPatrulla == false)
        {
            musica.Play();
            ReproduccionPatrulla = true;
        }
        if ( musicClip == 1 && ReproduccionChase == false)
        {
            musica.Play();
            ReproduccionChase = true;
        }
      
    }
}
