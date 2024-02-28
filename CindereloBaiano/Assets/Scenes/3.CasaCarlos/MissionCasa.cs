using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionCasa : MonoBehaviour
{
    public Transform player;
    public Transform carta;
    public TextMeshProUGUI mensagemInteracao;
    public TextMeshProUGUI mensagemSair;
    public RawImage cartaAberta;
    public bool podeAparecer;
    public bool lendo;
    public bool paraLer;

    // Start is called before the first frame update
    void Start()
    {
        carta.gameObject.SetActive(false);
        podeAparecer = false;
        StartCoroutine(TempoCarta());
    }

    // Update is called once per frame
    void Update()
    {
        if(podeAparecer == true)
        {
            if(Vector3.Distance(player.transform.position, carta.transform.position)<1f)
            {
                if(lendo == false)
                {
                    mensagemInteracao.gameObject.SetActive(true);
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        lendo = true;
                        StartCoroutine(Sair());
                    }

                }else{
                    if(paraLer == false)
                    {
                    mensagemInteracao.gameObject.SetActive(false);
                    cartaAberta.gameObject.SetActive(true);

                    }else{

                        mensagemSair.gameObject.SetActive(true);
                        if(Input.GetKeyUp(KeyCode.E))
                        {
                            Desativar();
                            cartaAberta.gameObject.SetActive(false);
                            mensagemSair.gameObject.SetActive(false);
                        }
                    }
                }
            }else{
                mensagemInteracao.gameObject.SetActive(false);
            }
            
        }
        
    }



    public void Desativar()
    {
        lendo = false;
        paraLer = false;
    }

    IEnumerator TempoCarta()
    {
        yield return new WaitForSeconds(90f);
        carta.gameObject.SetActive(true);
        podeAparecer = true;
    }

    IEnumerator Sair()
    {
        yield return new WaitForSeconds(5f);
        paraLer = true;
    }


}
