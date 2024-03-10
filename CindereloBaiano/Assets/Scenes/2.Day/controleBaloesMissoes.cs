using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class controleBaloesMissoes : MonoBehaviour
{
    public GameObject balaoTexto;
    public GameObject balaoCor;
    public TextMeshProUGUI textoBalao;
    public  GameObject cameraa;
    public TextMeshProUGUI sair;
    public GameObject imageCarlos;
    public GameObject imageCamila;
    public GameObject arco;

    bool sairBool;
    bool coroutineStarted = false;
    float velocidadePlayerA;
    float velocidadePlayerC;
    float sensibilidadeCamera;

    void Start()
    {
        velocidadePlayerA = GetComponent<Player>().velocidadeAndar;
        velocidadePlayerC = GetComponent<Player>().velocidadeCorrida;
        sensibilidadeCamera = cameraa.GetComponent<CameraController>().Sensibilidade;
    }
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
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "passaArco")
        {
            textoBalao.text = "Preciso ir para casa!\nMinha mamãe deve estar preocupada!";
            arco.SetActive(false);
            StartCoroutine(Texto());
        }
    }

    IEnumerator Texto()
    {
        balaoTexto.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        sair.gameObject.SetActive(true);
        sairBool = true;
    }

    public void SairCasa()
    {
        
    }
}
