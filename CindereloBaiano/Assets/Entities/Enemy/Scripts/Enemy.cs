using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy : MonoBehaviour
{

    public bool raiva = false;
    public float velocidadeOriginal = 0.5f;

    private GameObject player;
    private NavMeshAgent navMesh;
    private Animator animInimigo;
    private GameObject ataque;
    private GameObject olhosdeRaiva;


    // Start is called before the first frame update
    void Start()
    {
        olhosdeRaiva = GameObject.FindWithTag("OlhosRaiva");
        animInimigo = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        ataque = GameObject.FindWithTag("peCind");
        ataque.SetActive(false);
        olhosdeRaiva.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.destination = player.transform.position;
        animInimigo.SetBool("walk", true);

        if(Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            navMesh.speed = 0f;
            ataque.SetActive(true);
            animInimigo.SetBool("attack", true);
            StartCoroutine("attack");
        }else if(Vector3.Distance(transform.position, player.transform.position)>50f)
        {
            navMesh.speed = velocidadeOriginal + 30f;
        }else if(Vector3.Distance(transform.position, player.transform.position)<=50f && Vector3.Distance(transform.position, player.transform.position)>=2f)
        {
            navMesh.speed = velocidadeOriginal;
        }

        if(raiva == true)
        {
            animInimigo.SetBool("raiva", true);
            olhosdeRaiva.SetActive(true);
        }

    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(1.5f);
        animInimigo.SetBool("attack", false);
        navMesh.speed = velocidadeOriginal;
        ataque.SetActive(false);
    }
}
