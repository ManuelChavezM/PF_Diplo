using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona2 : MonoBehaviour
{
 
    public GameObject spawn02;
    public GameObject spawn03;
    public GameObject SPC1;



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if(spawn02.activeInHierarchy == false)
            {
                txtMision.instanceMision.txt2();
                spawn02.SetActive(true);
                spawn03.SetActive(true);

                SPC1.SetActive(false);

            }

        }
    }

   


}
