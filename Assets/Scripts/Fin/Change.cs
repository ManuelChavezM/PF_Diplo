using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Change : MonoBehaviour
{
    public GameObject cambio;
    // Update is called once per frame

    private void Awake()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        if (cambio.activeInHierarchy)
        {
            SceneManager.LoadScene(4);
        }
        
    }
}
