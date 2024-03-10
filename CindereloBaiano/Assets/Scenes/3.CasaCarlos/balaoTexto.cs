using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class balaoTexto : MonoBehaviour
{
    public GameObject balaoTxt;
    public GameObject balaoCor;
    public TextMeshProUGUI textoBalao;
    public TextMeshProUGUI sair;
    public GameObject imageCarlos;
    public GameObject imageCamila;

    bool sairBool;

    void Start()
    {
        textoBalao.text = "Humm...\nMamãe não esta em casa. Mas ela sempre deixa uma carta, quando isso acontece.\nPreciso encontra-la!";
        StartCoroutine(Texto());
    }

    void Update()
    {
        if(sairBool == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    sair.gameObject.SetActive(false);
                    balaoTxt.SetActive(false);
                    sairBool = false;
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

