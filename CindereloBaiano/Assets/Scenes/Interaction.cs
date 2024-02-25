using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    public TextMeshProUGUI missionText;
    public TextMeshProUGUI mensagemInteracao;
    public GameObject portaCasa;
    public GameObject portaBanco;
    public GameObject portaMercado;
    public GameObject portaIgreja;
    public GameObject portaAcademia;
    public GameObject gaiola;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(Vector3.Distance(portaCasa.transform.position, player.transform.position) < 5f) //interagindo com a porta da casa
        {

            
            if(GetComponent<MissionController>().praCasa == false)
            {
                Debug.Log("reconheceu a variavel");
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("apertou");
                    Vector3 playerPosition = player.transform.position;
                    mensagemInteracao.gameObject.SetActive(false);
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("CasaCarlos");

                }else
                {
                }
            }else if(GetComponent<MissionController>().praCasa == true){

                Debug.Log("voce ja fez essa missao");
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);

            }else{
                Debug.Log("não leu a variavel");
            }

        }else{
            missionText.gameObject.SetActive(false);
            mensagemInteracao.gameObject.SetActive(false);
        }
    }

}
/*
Alterei para aparecer a mensagem de interação apenas se o usuário não tiver feito a missão daquela porta, caso contrário irá aparecer que ele já fez aquela missão
*/
