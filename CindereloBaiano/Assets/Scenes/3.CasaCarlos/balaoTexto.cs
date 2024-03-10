using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class balaoTexto : MonoBehaviour
{
    public TextMeshProUGUI textoBalao;
    public TextMeshProUGUI sair;

    public  GameObject cameraa;

    public GameObject carta;
    public GameObject balaoTxt;
    public GameObject balaoCor;
    public GameObject imageCarlos;
    public GameObject imageCamila;

    bool sairBool;
    bool coroutineStarted = false;
    float velocidadePlayerA;
    float velocidadePlayerC;
    float sensibilidadeCamera;

    void Start()
    {
        textoBalao.text = "Humm...\nMamãe não esta em casa. Mas ela sempre deixa uma carta, quando isso acontece.\nPreciso encontra-la!";
        StartCoroutine(Texto());
        velocidadePlayerA = GetComponent<Player>().velocidadeAndar;
        velocidadePlayerC = GetComponent<Player>().velocidadeCorrida;
        sensibilidadeCamera = cameraa.GetComponent<CameraController>().Sensibilidade;
    }

    void Update()
    {
        if(balaoTxt.activeSelf)
        {
            cameraa.GetComponent<CameraController>().Sensibilidade = 0;
            GetComponent<Player>().velocidadeAndar = 0;
            GetComponent<Player>().velocidadeCorrida = 0;
            GetComponent<Animator>().SetBool("lendo", true);

        }else{
            cameraa.GetComponent<CameraController>().Sensibilidade = sensibilidadeCamera;
            GetComponent<Player>().velocidadeAndar = velocidadePlayerA;
            GetComponent<Player>().velocidadeCorrida = velocidadePlayerC;
            GetComponent<Animator>().SetBool("lendo", false);
        }

        if(sairBool == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                sair.gameObject.SetActive(false);
                balaoTxt.SetActive(false);
                sairBool = false;
            }
        }

        if(carta.GetComponent<MissionCasa>().leu == true)
        {
            textoBalao.text = "Preciso ir comprar coca e pão para a mamãe!";
            if(!coroutineStarted)
            {
                StartCoroutine(Texto());
                coroutineStarted = true;
            }
            if(sairBool == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    sair.gameObject.SetActive(false);
                    balaoTxt.SetActive(false);
                    sairBool = false;
                    coroutineStarted = false;
                }
            }
        }
    }

    IEnumerator Texto()
    {
        balaoTxt.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        sair.gameObject.SetActive(true);
        sairBool = true;
    }
}

