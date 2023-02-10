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
    public GameObject OrigenRay;
    


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
     
        if (Input.GetMouseButtonDown(0) && knifeAnimator.GetCurrentAnimatorStateInfo(0).IsName("New State") && GameManager.instanceGameManager.panelGameplay.activeInHierarchy)
        {
            mouseRay = new Ray(OrigenRay.transform.position,OrigenRay.transform.forward);
            Debug.DrawRay(mouseRay.origin, mouseRay.direction, Color.blue, 10f);
            knifeAnimator.SetTrigger("ataque");
            knifeAnimator.SetBool("active", true);
            AudioManager.instanceAudioManager.PlaySFX(SFXType.KNIFE);

            //Devuelve un bool
            if (Physics.Raycast(mouseRay, out mouseHit, 1.2f, mouseMask))
            {
                enemigo = mouseHit.collider.gameObject;
                enemigo.GetComponent<EnemyController>().ReduccionVida();
                AudioManager.instanceAudioManager.PlaySFX(SFXType.HIT);
                Debug.DrawRay(mouseRay.origin, mouseRay.direction, Color.red, 10f);


            }
        }
        if (knifeAnimator.GetCurrentAnimatorStateInfo(0).IsName("CuchilloAttack"))
        {
            knifeAnimator.SetBool("active", false);
        }
        

    }
}
