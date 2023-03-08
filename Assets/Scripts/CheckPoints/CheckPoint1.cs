using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour
{
    public SaveLoadSystem sistema;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            sistema.Save();
            Destroy(this.gameObject, 5f);
        }
    }

}
