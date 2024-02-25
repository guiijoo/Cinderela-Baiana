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
        if(Vector3.Distance(portaCasa.transform.position, player.transform.position) < 3f) //interagindo com a porta da casa
        {
            mensagemInteracao.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("apertou");
                if(GetComponent<MissionController>().praCasa == false)
                {
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);

                    SceneManager.LoadScene("CasaCarlos");

                }else if(GetComponent<MissionController>().praCasa == true)
                {
                    missionText.text = ("Você ja fez esta missão!");
                }
            }

        }else{
            mensagemInteracao.gameObject.SetActive(false);
        }
    }

}
