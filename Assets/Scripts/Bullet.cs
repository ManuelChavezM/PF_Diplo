using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explotion;
    private GameObject enemigo;


    //Metodo para detectar colisiones, recibe un objeto tipo colision
    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {
            //instanciar la explosion en el punto donde esta haciendo colision para que los ejes sean correctos con respecto al vector que detecta la colision
            //collision.contacts[0].point detecta el primer punto de contact
            Instantiate(explotion, collision.contacts[0].point + collision.contacts[0].normal * 0.001f, Quaternion.LookRotation(collision.contacts[0].normal * -1), collision.transform);
            enemigo = collision.gameObject;
            enemigo.GetComponent<EnemyController>().ReduccionVida(5.0f);
            AudioManager.instanceAudioManager.PlaySFX(SFXType.HIT);
        }

        if (collision.gameObject.tag == "Boss")
        {
            //instanciar la explosion en el punto donde esta haciendo colision para que los ejes sean correctos con respecto al vector que detecta la colision
            //collision.contacts[0].point detecta el primer punto de contact
            Instantiate(explotion, collision.contacts[0].point + collision.contacts[0].normal * 0.001f, Quaternion.LookRotation(collision.contacts[0].normal * -1), collision.transform);
            enemigo = collision.gameObject;
            enemigo.GetComponent<BossController>().ReduccionVida();
            AudioManager.instanceAudioManager.PlaySFX(SFXType.HIT);
        }

        //de esta forma nos aseguramos que se destruya el objeto
        Destroy(this.gameObject);

    }

}
