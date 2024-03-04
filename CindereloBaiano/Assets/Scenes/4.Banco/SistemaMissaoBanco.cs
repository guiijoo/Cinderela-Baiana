using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaMissaoBanco : MonoBehaviour
{
    public Transform player;
    public Transform dinheiro;
    public Transform porta;
    public Transform caixa;

    public TextMeshProUGUI interacao;
    public TextMeshProUGUI missao;

    public bool coletou;

    // Start is called before the first frame update
    void Start()
    {
        interacao.gameObject.SetActive(false);
        missao.gameObject.SetActive(false);
        dinheiro.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, dinheiro.transform.position)<2f)
        {
            if(caixa.GetComponent<LancaDinheiro>().contDin >= 1)
            {
                interacao.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    dinheiro.gameObject.SetActive(false);
                    dinheiro.transform.position = new Vector3(1000,-1000,1000);
                    coletou = true;
                }
            }

        }else if(Vector3.Distance(player.transform.position, porta.transform.position)<2f)
        {
            if(coletou==true)
            {
                interacao.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    PlayerPrefs.SetInt("banco", 1);
                    SceneManager.LoadScene("Day");
                }
            }else{
                missao.text = "Colete o dinheiro antes de sair!";
                missao.gameObject.SetActive(true);
            }

        }else{
            interacao.gameObject.SetActive(false);
            missao.gameObject.SetActive(false);
        }
    }
}
