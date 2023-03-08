using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Book : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with: " + other.gameObject.name);
        if (other.transform.CompareTag("Player"))
        {
            GameManager.instanceGameManager.Cargando();
            SceneManager.LoadScene(3);
        }
    }

}
