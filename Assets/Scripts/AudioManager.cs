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
    DAMAGE

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
        mixer.SetFloat("VolumenMusica",sliderVolMusica.value);
        mixer.SetFloat("VolumenSFX", sliderVolSFX.value);
        mixer.SetFloat("VolumenAmbiente", sliderVolAmbiente.value);

    }

    public void PlaySFx(SFXType sfxType)
    {
        switch(sfxType)
        {
            case SFXType.WALK:
                SFX.PlayOneShot(sfxCollection[0]);
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
