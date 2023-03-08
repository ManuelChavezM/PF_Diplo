using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class UIController : MonoBehaviour
{
    public GameObject panelPrincipal;
    public GameObject panelAbout;
    public GameObject btnContinuar;

    public void Play()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "Data.json"))
        {
            File.Delete(Application.persistentDataPath + "/" + "Data.json");
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
        
    }

    public void Continuar()
    {
        SceneManager.LoadScene(2);
    }

    public void ShowAbout()
    {
        panelAbout.SetActive(true);
        panelPrincipal.SetActive(false);
    }

    public void Back()
    {
        panelAbout.SetActive(false);
        panelPrincipal.SetActive(true);
    }

    public void Salir()
    {
        Debug.Log("SALISTE DEL JUEGO");
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        panelAbout.SetActive(false);
        panelPrincipal.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "Data.json"))
        {
            btnContinuar.SetActive(true);
        }

    }
}
