using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

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
    public GameObject wesley;
    public GameObject colJaula;
    public GameObject aaaaaai;
    public GameObject nonono;
    public GameObject sonsIncompeensiveis;

    public AudioSource audio;

    bool sairBool;
    public int dialogos;

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

        if(casa == false)
        {
            textoBalao.text = "Ow shit... Here we go again!";
            audio.Play();
            StartCoroutine(Texto());
        }else if(casa == true && banco == false)
        {
            nonono.GetComponent<AudioSource>().Play();
            textoBalao.text = "Nossa, mas estou sem dinheiro...\n\nHum... Será que consigo roubar um banco?";
            StartCoroutine(Texto());
        }else if(banco == true && zebu == false)
        {
            sonsIncompeensiveis.GetComponent<AudioSource>().Play();
            textoBalao.text = "Agora posso ir \"comprar\" coca e pão para minha mãe!";
            StartCoroutine(Texto());
        }else if(zebu == true && igreja == false)
        {
            textoBalao.text = "Pronto, agora só entregar para ela.\nEla disse que estava na missa, ela sempre vai na igreja da praça.";
            StartCoroutine(Texto());
        }else if(academia == true && praca == false)
        {
            textoBalao.text = "O que foi isso?!\nParece ter vindo da praça.";
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
            wesley.SetActive(false);

        }else{
            cameraa.GetComponent<CameraController>().Sensibilidade = sensibilidadeCamera;
            GetComponent<Player>().velocidadeAndar = velocidadePlayerA;
            GetComponent<Player>().velocidadeCorrida = velocidadePlayerC;
            GetComponent<Animator>().SetBool("lendo", false);
            wesley.SetActive(true);
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

        if(dialogos == 1)
        {
            if(Input.GetKeyDown(KeyCode.E))
                {
                    sair.gameObject.SetActive(false);
                    balaoTexto.SetActive(false);
                    dialogos++;
                }
        }else if(dialogos == 2)
        {
            textoBalao.text = "Ta gostosinha";
            StartCoroutine(FalaCarlos());
        }else if(dialogos == 3)
        {
            if(Input.GetKeyDown(KeyCode.E))
                {
                    sair.gameObject.SetActive(false);
                    balaoTexto.SetActive(false);
                    dialogos++;
                }
        }else if(dialogos > 3)
        {
            dialogos = 0;
            sair.gameObject.SetActive(false);
            balaoTexto.SetActive(false);
            
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "passaArco")
        {
            aaaaaai.GetComponent<AudioSource>().Play();
            textoBalao.text = "Preciso ir para casa!\nMinha mãe deve estar preocupada!";
            arco.SetActive(false);
            StartCoroutine(Texto());
        }else if(collider.gameObject.tag == "jaula" && academia == true){
            textoBalao.text = "Ai Ai Ai Carlos. Ayuada me, soy Yo, Camila Mexicana!";
            colJaula.SetActive(false);
            StartCoroutine(FalaCamila());
        }
    }

    public void Igreja()
    {
        textoBalao.text = "Holly shit police motherfucker!\nEntão, já que é assim, vou conquistar o shape para as Primas!\nAté lá a missa já acabou.";
        balaoTexto.GetComponent<mudaCor>().BalaoCarlos();
        StartCoroutine(Texto());
    }

    IEnumerator Texto()
    {
        balaoTexto.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        sair.gameObject.SetActive(true);
        sairBool = true;
    }

    IEnumerator FalaCamila()
    {
        balaoTexto.GetComponent<mudaCor>().BalaoCamila();
        balaoTexto.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        sair.gameObject.SetActive(true);
        dialogos++;
    }

    IEnumerator FalaCarlos()
    {
        balaoTexto.GetComponent<mudaCor>().BalaoCarlos();
        balaoTexto.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        sair.gameObject.SetActive(true);
        dialogos = 3;
    }
}
