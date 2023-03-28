using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
