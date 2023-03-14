using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public int numeroEnemys;
    public GameObject EnemigoPrefab;
    public Transform spawn;

    private bool activo = false;

    void Start()
    {
        spawn = GetComponent<Transform>();
    }

    public void Emboscada()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") &&  activo == false)
        {
            activo = true; //  que ya se activo el spawn
            for (int i = 0; i < numeroEnemys; i++)
            {
                Instantiate(EnemigoPrefab, spawn.position + new Vector3(i, 0f, -i),other.transform.localRotation * new Quaternion(1,1,-1,1));
            }
        }
    }


}