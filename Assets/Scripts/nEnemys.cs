using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nEnemys : MonoBehaviour
{
    
    
    public int numEnemys;
    public GameObject EnemigoPrefab;
    private GameObject enemy;
    public GameObject[] cajaEnemys;
    public Transform spawn;

 

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        cajaEnemys = new GameObject[numEnemys];
        spawn = GetComponent<Transform>();
        for (int i = 0; i < numEnemys; i++)
        {
            enemy = Instantiate(EnemigoPrefab,spawn.position + new Vector3(i, 0f, i), Quaternion.identity);
            cajaEnemys[i] = enemy;

        }
        
    }

    public void Limpiar()
    {
        for(int i=0 ; i < numEnemys; i++)
        {
            Destroy(cajaEnemys[i]);
        }
    }



}
