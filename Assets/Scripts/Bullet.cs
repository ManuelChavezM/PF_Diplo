using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explotion;


    //Metodo para detectar colisiones, recibe un objeto tipo colision
    void OnCollisionEnter(Collision collision)
    {
        //instanciar la explosion en el punto donde esta haciendo colision para que los ejes sean correctos con respecto al vector que detecta la colision
        //collision.contacts[0].point detecta el primer punto de contacto

        //Instantiate(explotion, collision.contacts[0].point + collision.contacts[0].normal * 0.001f, Quaternion.LookRotation(collision.contacts[0].normal * -1));


        Instantiate(explotion, collision.contacts[0].point + collision.contacts[0].normal * 0.001f, Quaternion.LookRotation(collision.contacts[0].normal * -1), collision.transform);



        //de esta forma nos aseguramos que se destruya el objeto
        Destroy(this.gameObject);

    }

}
