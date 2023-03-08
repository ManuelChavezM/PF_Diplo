using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    public string fileName;
    private StreamWriter sw;
    private StreamReader sr;
    public Data playerData;

    // variables a guardar
    public GameObject PLAYER;
    public FPController VIDA;
    public Shooter MUNICION;
    public GameManager CARGADORES;
    public GameManager BOTIQUINES;

    public GameObject SPC0;
    public GameObject SPC1;
    public GameObject SPC2;
    public GameObject SPC3;

    public GameObject cameraIntro;
    
    public void Awake()
    {
        Load();
    }


    public void Save()
    {
        playerData.playerPosition = PLAYER.transform.position;
        playerData.vida = VIDA.vida;
        playerData.balas = MUNICION.Municion;
        playerData.cargadores = CARGADORES.magazine;
        playerData.curas = BOTIQUINES.Cura;
        playerData.SPC0 = SPC0.activeInHierarchy;
        playerData.SPC1 = SPC1.activeInHierarchy;
        playerData.SPC2 = SPC2.activeInHierarchy;
        playerData.SPC3 = SPC3.activeInHierarchy;

        sw = new StreamWriter(Application.persistentDataPath + "/" + fileName,false);
        Debug.Log(Application.persistentDataPath + "/" + fileName);

        string objString = JsonUtility.ToJson(playerData);
        sw.WriteLine(objString);
        sw.Close();

    }


    public void Load()
    {
        playerData = new Data();
        if (File.Exists(Application.persistentDataPath+ "/" + fileName))
        {
            sr = new StreamReader(Application.persistentDataPath + "/" + fileName);
            string objString = sr.ReadToEnd();
            playerData = JsonUtility.FromJson<Data>(objString);


            PLAYER.transform.position = playerData.playerPosition;
            VIDA.vida = playerData.vida;
            MUNICION.Municion = playerData.balas;
            CARGADORES.magazine = playerData.cargadores;
            BOTIQUINES.Cura = playerData.curas;

            SPC0.SetActive(playerData.SPC0);
            SPC1.SetActive(playerData.SPC1);
            SPC2.SetActive(playerData.SPC2);
            SPC3.SetActive(playerData.SPC3);

            sr.Close();

            cameraIntro.transform.position = playerData.playerPosition; 

        }
        else
        {
            MUNICION.Municion = 5;
            VIDA.vida = 10;
        }


        
    }

}
