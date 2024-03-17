using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class bancoBalaoMissao : MonoBehaviour
{
    public GameObject balaoTexto;
    public GameObject balaoCor;
    public TextMeshProUGUI textoBalao;
    public  GameObject cameraa;
    public TextMeshProUGUI sair;
    public GameObject imageCarlos;

    bool sairBool;

    bool coroutineStarted = false;
    float velocidadePlayerA;
    float velocidadePlayerC;
    float sensibilidadeCamera;

    // Start is called before the first frame update
    void Start()
    {
        velocidadePlayerA = GetComponent<Player>().velocidadeAndar;
        velocidadePlayerC = GetComponent<Player>().velocidadeCorrida;
        sensibilidadeCamera = cameraa.GetComponent<CameraController>().Sensibilidade;

        textoBalao.text = "Vou usar o conhecimento de quando trabalhei aqui para invadir o caixa eletrônico!";
        StartCoroutine(Texto());
    }

    // Update is called once per frame
    void Update()
    {
        if(balaoTexto.activeSelf)
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
                balaoTexto.SetActive(false);
                sairBool = false;
            }
        }
        
    }

    IEnumerator Texto()
    {
        balaoTexto.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        sair.gameObject.SetActive(true);
        sairBool = true;
    }
}
