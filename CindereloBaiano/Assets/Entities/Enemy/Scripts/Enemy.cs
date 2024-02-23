using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy : MonoBehaviour
{

    private GameObject player;
    public float velocidadeOriginal = 0.5f;
    private NavMeshAgent navMesh;
    private Animator animInimigo;
    private GameObject ataque;


    // Start is called before the first frame update
    void Start()
    {
        animInimigo = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        ataque = GameObject.FindWithTag("peCind");
        ataque.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.speed = velocidadeOriginal;
        navMesh.destination = player.transform.position;
        animInimigo.SetBool("walk", true);

        if(Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            navMesh.speed = 0f;
            ataque.SetActive(true);
            animInimigo.SetBool("attack", true);
            StartCoroutine("attack");
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
