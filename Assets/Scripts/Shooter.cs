using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform originBullet;
    public float bulletForce;
    private GameObject tmpBullet;

 

    public int Municion;
    public GameObject chispa;

    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.instanceGameManager.panelGameplay.activeInHierarchy)
        {
            if (Municion != 0)
            {
               

                AudioManager.instanceAudioManager.PlaySFX(SFXType.SHOOT);

                Instantiate(chispa, originBullet.position, Quaternion.identity);

                tmpBullet = Instantiate(bullet, originBullet.position, Quaternion.identity);
                

                //orientacion de la bala por medio del uso del transform originbullet
                tmpBullet.transform.right = originBullet.transform.forward;

                //se agrega la fuerzo a la bala
                tmpBullet.GetComponent<Rigidbody>().AddForce(originBullet.forward * bulletForce, ForceMode.Impulse);

                Municion -= 1;
            }


        }

        
        GameManager.instanceGameManager.TextoBalas(Municion);
    }
}
