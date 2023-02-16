using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public int numeroEnemys;
    public GameObject EnemigoPrefab;
    private GameObject enemigo;
    public GameObject[] cajaEnemigos;
    public Transform spawn;

    void Start()
    {
        spawn = GetComponent<Transform>();
        
    }

    public void Emboscada()
    {
        for (int i = 0; i < numeroEnemys; i++)
        {
            enemigo = Instantiate(EnemigoPrefab, spawn.position + new Vector3(i, 0f, -i), Quaternion.identity);
            cajaEnemigos[i] = enemigo;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Emboscada();
        }
    }


}