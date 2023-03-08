using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona3 : MonoBehaviour
{
    public GameObject Rex;
    public GameObject muro1;
    public GameObject muro2;
    public GameObject SPC2;




    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            txtMision.instanceMision.txt3();
            Rex.SetActive(true);
            muro1.SetActive(true);
            muro2.SetActive(true);
            SPC2.SetActive(false);
           // Destroy(this.gameObject);

        }
    }
}
