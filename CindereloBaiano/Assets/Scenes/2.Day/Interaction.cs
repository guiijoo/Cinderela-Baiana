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
    public GameObject casaDaia;
    public GameObject portaWesley;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        float playerPosX = PlayerPrefs.GetFloat("playerPosX");
        float playerPosY = PlayerPrefs.GetFloat("playerPosY");
        float playerPosZ = PlayerPrefs.GetFloat("playerPosZ");
        if(playerPosX != 0)
        {
            Vector3 playerPosition = new Vector3(playerPosX, playerPosY, playerPosZ);
            player.transform.position = playerPosition;
        }
    }

    void Update()
    {
        if(Vector3.Distance(portaCasa.transform.position, player.transform.position) < 1.5f) //interagindo com a porta da casa
        {

            
            if(GetComponent<MissionController>().praCasa == false)
            {
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("apertou");
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("CasaCarlos");

                }

            }else if(GetComponent<MissionController>().praCasa == true){

                Debug.Log("voce ja fez essa missao");
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);

            }

        }else if(Vector3.Distance(portaBanco.transform.position, player.transform.position) < 1.5f){ //interagindo com o banco

            if(GetComponent<MissionController>().praCasa == true && GetComponent<MissionController>().banco == false)
            {
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("apertou");
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("Banco");

                }
            }else if(GetComponent<MissionController>().banco == true)
            {
                Debug.Log("voce ja fez essa missao");
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);
            }else{
                missionText.text = ("Você deve cumprir as outras missões antes!");
                missionText.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(portaMercado.transform.position, player.transform.position) < 1.5f){ //interagindo com o mercado

            if(GetComponent<MissionController>().banco == true && GetComponent<MissionController>().zebu == false)
            {
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("apertou");
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("InternoZebu");

                }
            }else if(GetComponent<MissionController>().zebu == true)
            {
                Debug.Log("voce ja fez essa missao");
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);
            }else{
                missionText.text = ("Você deve cumprir as outras missões antes!");
                missionText.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(portaIgreja.transform.position, player.transform.position) < 1.5f){ //interagindo com a igreja

            if(GetComponent<MissionController>().zebu == true && GetComponent<MissionController>().igreja == false)
            {
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<MissionController>().igreja = true;
                    mensagemInteracao.gameObject.SetActive(false);
                    PlayerPrefs.SetInt("igreja", 1);
                }
            }else if(GetComponent<MissionController>().igreja == true)
            {
                Debug.Log("voce ja fez essa missao");
                missionText.text = "Pretos não são bem vindos aqui!";
                missionText.gameObject.SetActive(true);
            }else{
                missionText.text = ("Você deve cumprir as outras missões antes!");
                missionText.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(portaAcademia.transform.position, player.transform.position) < 1.5f){ //interagindo com a academia

            if(GetComponent<MissionController>().igreja == true && GetComponent<MissionController>().academia == false)
            {
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("apertou");
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("Academia");

                }
            }else if(GetComponent<MissionController>().academia == true)
            {
                Debug.Log("voce ja fez essa missao");
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);
            }else{
                missionText.text = ("Você deve cumprir as outras missões antes!");
                missionText.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(portaAcademia.transform.position, player.transform.position) < 1.5f){ //interagindo com a praça

            if(GetComponent<MissionController>().academia == true && GetComponent<MissionController>().praca == false)
            {
                mensagemInteracao.text = "Aperte 'E' para inspecionar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("apertou");
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("Night");

                }
            }else if(GetComponent<MissionController>().praca == true)
            {
                Debug.Log("voce ja fez essa missao");
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);
            }else{
                missionText.text = ("Você deve cumprir as outras missões antes!");
                missionText.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(casaDaia.transform.position, player.transform.position) < 30f)
        {
            mensagemInteracao.text = "Aperte 'E' para inspecionar!";
            mensagemInteracao.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                Vector3 posicaoPlayer = portaWesley.transform.position;
                player.transform.position = posicaoPlayer;
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