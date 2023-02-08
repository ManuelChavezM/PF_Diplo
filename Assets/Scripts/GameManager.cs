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
    public TMP_Text txtBalas;
    public TMP_Text txtCargador;
    public Image imgVida;
    public int magazine; // nuemero de cargadores recogido
    //public AudioSource musica;

    void Awake()
    {
        instanceGameManager = this;
    }

    public void Continuar()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
        panelGameplay.SetActive(true);
        //musica.UnPause();
        //AudioManager.instanceAudioManager.musica.UnPause();

    }
    public void Pausa()
    {
        Time.timeScale = 0; //detener todos los procesos con animacion y codigo pero no de interfaz
        panelPausa.SetActive(true);
        panelGameplay.SetActive(false);
        //AudioManager.instanceAudioManager.musica.Pause();
        // musica.Pause();
        //musica.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
        TextoCargador(magazine);
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

    public void TextoCargador(int cargador)
    {
        txtCargador.text = "" + cargador;
    }

    public void TextoBalas(int balas)
    {
        txtBalas.text = "" + balas;
    }

    public void Salir()
    {
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
