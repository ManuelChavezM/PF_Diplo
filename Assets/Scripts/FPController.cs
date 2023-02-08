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

    public float jumpForce = 5f;

    public Shooter Arma;

    //varibles de para el manejo de la vida y calculo del life bar
    public float vida;
    public float vidaMAX;
    public float LifeValue;


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

        movement.y = yVel;
        fprb.velocity = movement;

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            fprb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }*/

        if( vida <= 0)
        {
            VidaCero();
        }

        if(vida != vidaMAX)
        {
            LifeValue = vida / vidaMAX;
            GameManager.instanceGameManager.ImagenVida(LifeValue);
        }

        if (Input.GetKeyDown(KeyCode.R) && GameManager.instanceGameManager.magazine != 0)
        {
            GameManager.instanceGameManager.RestaMagazine();
            Arma.Municion = 5;
        }

    }

    public void VidaCero()
    {
        SceneManager.LoadScene(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cargador")
        {
            
            GameManager.instanceGameManager.SumaMagazine();
            Destroy(collision.gameObject);

        }


    }


}
