using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Ray mouseRay;

    //recolecta toda la informacion con la que choca el rayo
    private RaycastHit mouseHit;


    public LayerMask mouseMask;


   // private GameObject weaponManager;

    private void Start()
    {
        //weaponManager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Devuelve un bool
            if (Physics.Raycast(mouseRay, out mouseHit, 10f, mouseMask))
            {
                //if (mouseHit.transform.tag == "Enemy")
                //{
                Destroy(mouseHit.transform.gameObject);
                Debug.DrawRay(mouseRay.origin, mouseRay.direction, Color.red, 10f);

                //weaponManager.SendMessage("ChangeWeapon",1);

                // para que no lance un error cuando no tiene el metodo
                //weaponManager.SendMessage("Chadjshjd", SendMessageOptions.DontRequireReceiver);

                //Accediendo al component y llamar al metodo correspondiente
               // weaponManager.GetComponent<WeaponManager>().ChangeWeapon(1);
                //}

            }
        }

    }
}
