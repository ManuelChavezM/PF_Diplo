using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float vida;


    private void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fprb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if( vida <= 0)
        {
            VidaCero();
        }

    }

    public void VidaCero()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cargador")
        {
            Arma.Municion = 5;
            Destroy(collision.gameObject);

        }


    }

}
