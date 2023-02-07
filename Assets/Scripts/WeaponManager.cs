using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] Weapons;
    public GameObject Disparos;
    public GameObject Knife;
    // Start is called before the first frame update
    void Start()
    {
        ClearWeapons();
        Weapons[0].SetActive(true);
        Knife.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Weapons[0].activeInHierarchy)
            {
                Weapons[0].SetActive(false);
                Disparos.SetActive(false);
                Weapons[1].SetActive(true);
                Knife.SetActive(true);
            }
            else
            {
                if (Weapons[1].activeInHierarchy)
                {
                    Weapons[1].SetActive(false);
                    Disparos.SetActive(true);
                    Weapons[0].SetActive(true);
                    Knife.SetActive(false);
                }
            }

        }
        
    }


    private void ClearWeapons()
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);
        }
    }

}
