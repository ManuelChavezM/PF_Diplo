using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public Animator enemyAnimator;
    public Vector2 patrolRange;
    public float patrolTime;
    private Transform playerTransform;
    private Vector3 randomPosition;
    private EnemyState currentState;

    private float tiempoDamage = 0f;
    private float tiempoDamageContado = 1f;

    public FPController vidaJugador;
    private GameObject Jugador;

    public float Vida;
    public float vidaMax;
    /*public Image imgVida;
    private float valueLifeEnemy;*/

    private int D = 0;


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

        currentState = EnemyState.PATROL;
        UpdateState();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.CHASE:
                //perseguir al jugador asignandole la posicion del jugador a partir de su transform
                enemyAgent.SetDestination(playerTransform.position);  //Validar si alcanza al jugador
              /*  AudioManager.instanceAudioManager.PlayMusic(1);*/
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
        }
    

        enemyAnimator.SetFloat("speed", enemyAgent.velocity.sqrMagnitude);

        /*
        if (Vida < vidaMax && Vida != 0)
        {
            valueLifeEnemy = Vida / vidaMax;
            imgVida.fillAmount = valueLifeEnemy;

        }*/


        if (Vida == 0)
        {
           /* AudioManager.instanceAudioManager.ReproduccionPatrulla = false;
            AudioManager.instanceAudioManager.ReproduccionChase = false;
            AudioManager.instanceAudioManager.PlayMusic(0);*/
            VidaCero();
        }

       /* Lifebar();*/

    }

    private void UpdateState()
    {
        switch (currentState)
        {
            case EnemyState.PATROL:
                //corrutina que deice nombre del metodo, off set y tiempo para que lo repita 
                InvokeRepeating("GenerateRandomDestination", 0f, patrolTime);
               /* if (AudioManager.instanceAudioManager.ReproduccionChase == false)
                {
                    AudioManager.instanceAudioManager.PlayMusic(0);
                }*/
                break;
        }
    }

    private void GenerateRandomDestination()
    {
        randomPosition = transform.position + new Vector3(Random.Range(-patrolRange.x, patrolRange.x), 0f, Random.Range(-patrolRange.y, patrolRange.y));
        enemyAgent.SetDestination(randomPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with: " + other.gameObject.name);
        if (other.transform.CompareTag("Player"))
        {
            enemyAnimator.SetBool("PlayerDetectado", true);
            if (currentState == EnemyState.PATROL)
            {
                currentState = EnemyState.CHASE;
                CancelInvoke("GenerateRandomDestination");
            }
        }
        else
        {
            currentState = EnemyState.PATROL;
            UpdateState();
        }


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
                vidaJugador.vida = vidaJugador.vida - 1;
                Debug.Log("Haciendo daño: " + D);
            }

        }

    }

    public void ReduccionVida()
    {
        Vida = Vida - 5f;

    }

    public void VidaCero()
    {
       /* PlayerProfile.instance.EnemigoMuerto();*/
        Destroy(this.gameObject);
    }

    /*public void Lifebar()
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

    }*/


}


public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
};