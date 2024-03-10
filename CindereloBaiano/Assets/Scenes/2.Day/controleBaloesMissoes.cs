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
    bool casa;
    bool banco;
    bool zebu;
    bool igreja;
    bool academia;
    bool praca;


    bool coroutineStarted = false;
    float velocidadePlayerA;
    float velocidadePlayerC;
    float sensibilidadeCamera;

    void Awake()
    {
        casa = PlayerPrefs.GetInt("praCasa", 0) == 1;
        banco = PlayerPrefs.GetInt("banco", 0) ==1;
        zebu = PlayerPrefs.GetInt("zebu", 0) == 1;
        igreja = PlayerPrefs.GetInt("igreja", 0) == 1;
        academia = PlayerPrefs.GetInt("academia", 0) == 1;
        praca = PlayerPrefs.GetInt("praca",0) == 1;

        velocidadePlayerA = GetComponent<Player>().velocidadeAndar;
        velocidadePlayerC = GetComponent<Player>().velocidadeCorrida;
        sensibilidadeCamera = cameraa.GetComponent<CameraController>().Sensibilidade;

        if(casa == true && banco == false)
        {
            textoBalao.text = "Nossa, mas estou sem dinheiro...\n\nHum... Será que consigo roubar um banco?";
            StartCoroutine(Texto());
        }else if(banco == true && zebu == false)
        {
            textoBalao.text = "Agora posso ir \"comprar\" coca e pão para minha mãe!";
            StartCoroutine(Texto());
        }else if(zebu == true && igreja == false)
        {
            textoBalao.text = "Pronto, agora só entregar para ela.\nEla disse que estava na missa, ela sempre vai na igreja da praça.";
            StartCoroutine(Texto());
        }
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
            textoBalao.text = "Preciso ir para casa!\nMinha mãe deve estar preocupada!";
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
}
