using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;
    public GameObject panelGameplay;
    public GameObject panelPausa;
    public GameObject panelOpciones;
    public TMP_Text txtBalas;
    public TMP_Text txtCargador;
    public Image imgVida;
    public int magazine; // nuemero de cargadores recogido
    public int Cura;
    public TMP_Text txtCura;
    //public AudioSource musica;

    void Awake()
    {
        instanceGameManager = this;
    }

    public void Continuar()
    {
        Time.timeScale = 1;
        AudioManager.instanceAudioManager.PlaySFX(SFXType.BUTTON);
        panelPausa.SetActive(false);
        panelOpciones.SetActive(false);
        panelGameplay.SetActive(true);
        AudioManager.instanceAudioManager.musica.UnPause();
        AudioManager.instanceAudioManager.ambiente.Play();
       
    }
    public void Pausa()
    {
        Time.timeScale = 0; //detener todos los procesos con animacion y codigo pero no de interfaz
        AudioManager.instanceAudioManager.PlaySFX(SFXType.BUTTON);
        panelPausa.SetActive(true);
        panelGameplay.SetActive(false);
        panelOpciones.SetActive(false);
        AudioManager.instanceAudioManager.musica.Pause();
        AudioManager.instanceAudioManager.ambiente.Pause();
       
    }

    public void Opciones()
    {
        AudioManager.instanceAudioManager.PlaySFX(SFXType.BUTTON);
        panelPausa.SetActive(false);
        panelGameplay.SetActive(false);
        panelOpciones.SetActive(true);
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && panelGameplay.activeInHierarchy)
        {
            Pausa();
        }
        TextoCargador(magazine);
        TextoCura(Cura);
    }

    public void ImagenVida(float fill)
    {
        imgVida.fillAmount = fill;
        Lifebar();
    }

    public void SumaMagazine()
    {
        magazine++;
    }
    public void RestaMagazine()
    {
        if(magazine != 0)
        {
            magazine--;
        }
    }

    public void SumaCura()
    {
        Cura++;
    }
    public void RestaCura()
    {
        if (Cura != 0)
        {
            Cura--;
        }
    }


    public void TextoCargador(int cargador)
    {
        txtCargador.text = "" + cargador;
    }

    public void TextoBalas(int balas)
    {
        txtBalas.text = "" + balas;
    }

    public void TextoCura(int cura)
    {
        txtCura.text = "" + cura;
    }

    public void Salir()
    {
        AudioManager.instanceAudioManager.PlaySFX(SFXType.BUTTON);
        Debug.Log("SALISTE DEL JUEGO");
        Application.Quit();
    }

    public void Lifebar()
    {
        if (imgVida.fillAmount >= 0.7f)
        {

            imgVida.color = Color.green;
        }
        else
        {
            if (imgVida.fillAmount <= 0.3f)
            {
                imgVida.color = Color.red;
            }
            else
            {
                imgVida.color = Color.yellow;
            }
        }

    }
}
