using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Ray mouseRay;
    //recolecta toda la informacion con la que choca el rayo
    private RaycastHit mouseHit;
    public LayerMask mouseMask;
    private GameObject enemigo;
    private GameObject cuchillo;
    public Animator knifeAnimator;
    


   // private GameObject weaponManager;

    private void Start()
    {
        cuchillo = GameObject.FindGameObjectWithTag("knife");
        knifeAnimator = cuchillo.GetComponent<Animator>();
        //weaponManager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (knifeAnimator.GetCurrentAnimatorStateInfo(0).IsName("New State"))
            {
                knifeAnimator.SetTrigger("ataque");
            }
           


            //Devuelve un bool
            if (Physics.Raycast(mouseRay, out mouseHit, 1.2f, mouseMask))
            {
                enemigo = mouseHit.collider.gameObject;
                enemigo.GetComponent<EnemyController>().ReduccionVida();
                Debug.DrawRay(mouseRay.origin, mouseRay.direction, Color.red, 10f);


            }
        }

    }
}
