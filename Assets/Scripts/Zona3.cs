using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona3 : MonoBehaviour
{
    public GameObject Rex;
    public GameObject muro1;
    public GameObject muro2;



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Rex.SetActive(true);
            muro1.SetActive(true);
            muro2.SetActive(true);
            Destroy(this.gameObject);

        }
    }
}
