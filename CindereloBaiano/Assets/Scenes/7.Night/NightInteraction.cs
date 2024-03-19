
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightInteraction : MonoBehaviour
{

    public Transform player;
    public GameObject casaDaia;
    public GameObject casaNovaDaia;
    public GameObject jaula;
    public GameObject tpCinderela;

    public Transform Cinderela;

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
                Vector3 posCinderela = tpCinderela.transform.position;
                Cinderela.transform.position = posCinderela;
                player.transform.position = posicaoPlayer;
            }

        }else{
            interagir.gameObject.SetActive(false);
            missionTXT.gameObject.SetActive(false);
        }
    }
}
