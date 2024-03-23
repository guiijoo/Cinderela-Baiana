
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

    public Transform cinderela;

    public TextMeshProUGUI interagir;
    public TextMeshProUGUI missionTXT;
    public GameObject textoInicial;
    Vector3 posCinderela;
    Vector3 posicaoPlayer;
    
    void Start()
    {
        posCinderela = tpCinderela.transform.position;
        posicaoPlayer = casaNovaDaia.transform.position;
    }
    void Update()
    {

      if(!textoInicial.activeSelf)
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
                    cinderela.gameObject.SetActive(false);
                    cinderela.position = posCinderela;
                    player.position = posicaoPlayer;
                    cinderela.gameObject.SetActive(true);
                }

            }else{
                interagir.gameObject.SetActive(false);
                missionTXT.gameObject.SetActive(false);
            }
      }else{
            missionTXT.gameObject.SetActive(false);
            interagir.gameObject.SetActive(false);
      }
    }
}
