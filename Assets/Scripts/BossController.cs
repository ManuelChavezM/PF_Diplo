using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public Animator enemyAnimator;
    private Transform playerTransform;
    private EnemyState currentState;

    private float tiempoDamage = 0f;
    private float tiempoDamageContado = 1f;

    public FPController vidaJugador;
    private GameObject Jugador;

    public float Vida;
    public float vidaMax;
    public Image imgVida;
    private float valueLifeEnemy;

    private int D = 0;
    private float tiempoCorriendo = 0f;
    private float tiempoLimite = 1f;
    private int tiempoMax = 0;

    public GameObject Cargador;
    public GameObject Cura;
    private float result;


    // Start is called before the first frame update
    void Start()
    {
        vidaMax = Vida;

        //Se extrae los componentes
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();


        //conectarse con el script del jugador 
        Jugador = GameObject.FindGameObjectWithTag("Player");
        vidaJugador = Jugador.GetComponent<FPController>();

        //se obtiene que obtner el tranform del jugador por medio de su tag
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        currentState = EnemyState.CHASE;
       
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.CHASE:
                //perseguir al jugador asignandole la posicion del jugador a partir de su transform
                // SetDestiantion aplica funciona en el Swicht
                enemyAgent.SetDestination(playerTransform.position);  //Validar si alcanza al jugador
               // AudioManager.instanceAudioManager.PlayMusic(1);
                if (enemyAgent.velocity.sqrMagnitude == 0)
                {
                    currentState = EnemyState.ATTACK;
                    enemyAnimator.SetBool("attack", true);
                    VerificarAnimacion();
                }
                break;

            case EnemyState.ATTACK:
                if (enemyAgent.velocity.sqrMagnitude != 0)
                {
                    currentState = EnemyState.CHASE;
                    enemyAnimator.SetBool("attack", false);
                }
                //perseguir al jugador asignandole la posicion del jugador a partir de su transform
                enemyAgent.SetDestination(playerTransform.position);
                VerificarAnimacion();
                break;

            case EnemyState.DIE:
                enemyAnimator.SetTrigger("Die");
                enemyAgent.SetDestination(GetComponent<Transform>().position);
                if (tiempoMax == 3)
                {

                    VidaCero();

                }
                else
                {
                    HacerTiempo();
                }

                break;
        }


        enemyAnimator.SetFloat("speed", enemyAgent.velocity.sqrMagnitude);


        if (Vida < vidaMax)
        {
            valueLifeEnemy = Vida / vidaMax;
            imgVida.fillAmount = valueLifeEnemy;

        }


        if (Vida <= 0)
        {

            currentState = EnemyState.DIE;
            CancelInvoke("GenerateRandomDestination");
        }

        Lifebar();

    }


   
  

    public void VerificarAnimacion()
    {

        if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            tiempoDamage += Time.deltaTime;
            if (tiempoDamage >= tiempoDamageContado)
            {
                tiempoDamage = 0f;
                D++;
                AudioManager.instanceAudioManager.PlaySFX(SFXType.DAMAGE);
                vidaJugador.vida = vidaJugador.vida - 1;
                Debug.Log("Haciendo daño: " + D);
            }

        }

    }

    public void ReduccionVida()
    {
      
        AudioManager.instanceAudioManager.PlaySFX(SFXType.ENEMY);
        Vida = Vida - 5f;

    }

    public void VidaCero()
    {
        Drop();
        AudioManager.instanceAudioManager.ReproduccionPatrulla = false;
        AudioManager.instanceAudioManager.ReproduccionChase = false;
        if (AudioManager.instanceAudioManager.musica.clip != AudioManager.instanceAudioManager.musicaCollection[0])
        {
            AudioManager.instanceAudioManager.PlayMusic(0);
        }
        //Destroy(this.gameObject);
    }

    public void Lifebar()
    {
        if (imgVida.fillAmount >= 0.7f)
        {

            imgVida.color = Color.green;
        }
        else
        {
            if (imgVida.fillAmount <= 0.3f)
            {
                imgVida.color = Color.red;
            }
            else
            {
                imgVida.color = Color.yellow;
            }
        }

    }

    public void HacerTiempo()
    {
        tiempoCorriendo += Time.deltaTime;
        if (tiempoCorriendo >= tiempoLimite)
        {
            tiempoCorriendo = 0f;
            tiempoMax++;
        }
    }

    public void Drop()
    {
        result = Random.Range(1f, 2f);
        Debug.Log(result);
        if (result <= 1.7f)
        {
            Instantiate(Cargador, GetComponent<Transform>().position, Quaternion.identity);
        }
        if (result > 1.7f)
        {
            Instantiate(Cura, GetComponent<Transform>().position, Quaternion.identity);
        }
    }


}


public enum BossState
{
    CHASE,
    ATTACK,
    DIE
};