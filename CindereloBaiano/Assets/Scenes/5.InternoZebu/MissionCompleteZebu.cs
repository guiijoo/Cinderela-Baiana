using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionCompleteZebu : MonoBehaviour
{
    public bool coca;
    public bool pao;
    public Transform cocaGo;
    public Transform paoGo;
    public GameObject porta;
    public Transform player;
    public TextMeshProUGUI mensagemInteragir;
    public TextMeshProUGUI missionText;
    void Update()
    {
        if(Vector3.Distance(porta.transform.position, player.transform.position) < 1.5f)
        {
            if(coca == true && pao == true)
            {
                mensagemInteragir.text = "aperte 'E' para sair";
                mensagemInteragir.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    PlayerPrefs.SetInt("zebu", 1);
                    SceneManager.LoadScene("Day");
                }
            }else{
                missionText.gameObject.SetActive(true);
                missionText.text = "Busque os itens antes de vir para cá!";
            }
 
        }else if(Vector3.Distance(player.transform.position, cocaGo.transform.position)<2f){
            mensagemInteragir.text = "aperte 'E' para roubar";
            mensagemInteragir.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                coca = true;
                cocaGo.gameObject.SetActive(false);
                cocaGo.transform.position = new Vector3(1000,-1000,1000);
            }

        }else if(Vector3.Distance(player.transform.position, paoGo.transform.position)<2f){
            mensagemInteragir.text = "aperte 'E' para roubar";
            mensagemInteragir.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                pao = true;
                paoGo.gameObject.SetActive(false);
                paoGo.transform.position = new Vector3(1000,-1000,1000);
            }

        }else{
            mensagemInteragir.gameObject.SetActive(false);
            missionText.gameObject.SetActive(false);
        }
        
    }
}
