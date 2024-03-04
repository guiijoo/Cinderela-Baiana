<<<<<<< HEAD
using TMPro;
=======
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
>>>>>>> 31e42d322ca6b007b4b41c2390ce00c8888a7aef
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightInteraction : MonoBehaviour
{

    public Transform player;
    public GameObject casaDaia;
    public GameObject casaNovaDaia;
    public GameObject jaula;

    public TextMeshProUGUI interagir;
    public TextMeshProUGUI missionTXT;
    

    void Update()
    {
        if(Vector3.Distance(player.transform.position, jaula.transform.position)< 5f)
        {
            if(player.GetComponent<Player>().poderMaximo == true)
            {
                interagir.text = "Aperte 'E' para resgatar a Mexicana!";
                interagir.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("Victory");
                }
            }else{
                missionTXT.text = "Colete TODOS os alteres!";
                missionTXT.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(player.transform.position, casaDaia.transform.position)<15f)
        {
            interagir.text = "Aperte 'E' para interagir!";
            interagir.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                Vector3 posicaoPlayer = casaNovaDaia.transform.position;
                player.transform.position = posicaoPlayer;
            }

        }else{
            interagir.gameObject.SetActive(false);
            missionTXT.gameObject.SetActive(false);
        }
    }
}
