using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona1 : MonoBehaviour
{
    public GameObject spawn01;
    public GameObject SPC0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (spawn01.activeInHierarchy == false)
            {
                spawn01.SetActive(true);
                SPC0.SetActive(false);

            }

        }
    }
}
