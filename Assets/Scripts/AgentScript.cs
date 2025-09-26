using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform targetTR;
    [SerializeField] Animator anim;
    [SerializeField] float velocity;
    [SerializeField] Transform[] Puntos;
    public bool patrullando = true;
    private int currentPatrolPoint = 0;
    public static AgentScript Instance;
    public GameObject jugador;
    public bool Persigiendo = false;
    public bool jugadorEnVision = false;
    public int tiempoSinVision = 0;

    private void Awake()
    {
        Instance = this;
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        if (patrullando)
        {
            Persigiendo = false;
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                currentPatrolPoint = (currentPatrolPoint + 1) % Puntos.Length;
                agent.SetDestination(Puntos[currentPatrolPoint].position);
            }
        }
            else
            {
                agent.SetDestination(jugador.transform.position);
                Persigiendo = true;    
            }
            velocity = agent.velocity.magnitude;
            anim.SetFloat("Speed",velocity);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Perdiste");
        }
    }
}
