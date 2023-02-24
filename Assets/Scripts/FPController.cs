using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPController : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    public Transform cameraTransform;
    private Rigidbody fprb;
    private Vector3 movement;

    private float yVel;
    private bool locked;

    public Shooter Arma;

    //varibles de para el manejo de la vida y calculo del life bar
    public float vida;
    public float vidaMAX;
    public float LifeValue;

    public GameObject rifle;

    private void Start()
    {
        vidaMAX = vida;
        //se le indica que traiga el componente rgidbody 
        fprb = GetComponent<Rigidbody>();
        locked = true;
    }

    public void UnlockControll()
    {
        locked = false;
    }

    private void Update()
    {
        if (locked == true)
        {
            return;
        }

        movement = Vector3.zero;

        yVel = fprb.velocity.y;

        //Movimiento del jugador con el teclado

        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime * Input.GetAxis("Mouse X"));
        movement = Camera.main.transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        movement += Camera.main.transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

        if (yVel <= 1.0f)
        {
            movement.y = yVel;
        }
        else
        {
            movement.y = 1.0f;
        }
        
       
        fprb.velocity = movement;

        if(Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f && GameManager.instanceGameManager.panelGameplay.activeInHierarchy)
        {
            AudioManager.instanceAudioManager.PlaySFX(SFXType.WALK);
        }

        if( vida <= 0)
        {
            VidaCero();
        }

        ActualizarLifeBar();
      

        if (Input.GetKeyDown(KeyCode.E) && GameManager.instanceGameManager.magazine != 0 && rifle.activeInHierarchy)
        {
            AudioManager.instanceAudioManager.PlaySFX(SFXType.RELOAD);
            GameManager.instanceGameManager.RestaMagazine();
            Arma.Municion = 5;
        }

        if (Input.GetKeyDown(KeyCode.R) && GameManager.instanceGameManager.Cura != 0 && vida!=vidaMAX)
        {
            GameManager.instanceGameManager.RestaCura();
            vida = vidaMAX;
            LifeValue = vida / vidaMAX;
            GameManager.instanceGameManager.ImagenVida(LifeValue);
           
            
        }

    }

    public void VidaCero()
    {
        SceneManager.LoadScene(2);
    }

    public void ActualizarLifeBar()
    {
        if (vida != vidaMAX)
        {
            LifeValue = vida / vidaMAX;
            GameManager.instanceGameManager.ImagenVida(LifeValue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cargador")
        {
            
            GameManager.instanceGameManager.SumaMagazine();
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Cura")
        {
            GameManager.instanceGameManager.SumaCura();
            Destroy(collision.gameObject);

        }


    }


}
