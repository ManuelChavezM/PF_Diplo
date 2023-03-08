using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona4 : MonoBehaviour
{
    public GameObject spawn04;
    public GameObject spawn05;
    public GameObject SPC3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (spawn04.activeInHierarchy == false)
            {
                txtMision.instanceMision.txt4();
                spawn04.SetActive(true);
                spawn05.SetActive(true);
                SPC3.SetActive(false);

            }

        }
    }


}
