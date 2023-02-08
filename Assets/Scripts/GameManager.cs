using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;
    public GameObject panelGamplay;
    
    // Start is called before the first frame update
    void Awake()
    {
        instanceGameManager = this;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
