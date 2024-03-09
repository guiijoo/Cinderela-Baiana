using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionCasa : MonoBehaviour
{
    public Transform player;
    public Transform carta;
    public TextMeshProUGUI mensagemInteracao;
    public TextMeshProUGUI mensagemSair;
    public TextMeshProUGUI missionText;
    public RawImage cartaAberta;
    public Transform porta;
    public bool leu;
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
            if(Vector3.Distance(player.transform.position, carta.transform.position)<1.3f)
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
                            leu = true;
                            Desativar();
                            cartaAberta.gameObject.SetActive(false);
                            mensagemSair.gameObject.SetActive(false);
                        }
                    }
                }
            }else if(Vector3.Distance(porta.transform.position, player.transform.position)<1.5f){
                if(leu == true)
                {
                    mensagemInteracao.gameObject.SetActive(true);
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        PlayerPrefs.SetInt("praCasa", 1);
                        SceneManager.LoadScene("Day");

                    }
                }else
                {
                    missionText.text = "Você deve encontrar a carta";
                    missionText.gameObject.SetActive(true);
                }   
                
            }else{
                missionText.gameObject.SetActive(false);
                mensagemInteracao.gameObject.SetActive(false);
                mensagemSair.gameObject.SetActive(false);
                cartaAberta.gameObject.SetActive(false);
            }
            
        }else if(podeAparecer == false || leu == false)
        {
            if(Vector3.Distance(porta.transform.position, player.transform.position)<1.3f){
            missionText.text = "Você deve encontrar a carta";
            missionText.gameObject.SetActive(true);
            }else{
                missionText.gameObject.SetActive(false);
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
        yield return new WaitForSeconds(10f);
        paraLer = true;
    }


}
