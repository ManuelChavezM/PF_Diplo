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
        /* transform.Translate(Vector3.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));
         transform.Translate(Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));*/

        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime * Input.GetAxis("Mouse X"));

        //Formas de rotar el transform de la camera
        /*cameraTransform.Rotate(Vector3.right * speedRotation * -Input.GetAxis("Mouse Y"));*/

        //transform.GetChild(0).Rotate(Vector3.right * speedRotation * -Input.GetAxis("Mouse Y"));

        // Camera.main.transform.Rotate(Vector3.right * speedRotation * Time.deltaTime * -Input.GetAxis("Mouse Y"));



        /*movement = transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        movement += transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal");*/

        movement = Camera.main.transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        movement += Camera.main.transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

        movement.y = yVel;
        fprb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fprb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

}
