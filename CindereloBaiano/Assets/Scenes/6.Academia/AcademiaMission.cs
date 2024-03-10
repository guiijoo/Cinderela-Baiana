using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AcademiaMission : MonoBehaviour
{
    public Transform player;
    public Transform drPenis;
    public Transform porta;

    public TextMeshProUGUI mensagemInteragir;
    public TextMeshProUGUI missionText;

    public RawImage carlosDrPenis;

    public bool podeSair;


    // Start is called before the first frame update
    void Start()
    {
        podeSair = false;
        mensagemInteragir.gameObject.SetActive(false);
        missionText.gameObject.SetActive(false);
        carlosDrPenis.gameObject.SetActive(false);
    }


    void Update()
    {
        if(Vector3.Distance(player.transform.position, drPenis.transform.position)<1.5f)
        {
            mensagemInteragir.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                mensagemInteragir.gameObject.SetActive(false);
                StartCoroutine(Foto());
                podeSair = true;
                drPenis.gameObject.SetActive(false);
                drPenis.transform.position = new Vector3(0,-1000,0);
            }
        }else if(Vector3.Distance(player.transform.position, porta.transform.position)<1.5f)
        {
            if(podeSair == true)
            {
                mensagemInteragir.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    PlayerPrefs.SetInt("academia",1);
                    SceneManager.LoadScene("Day");
                }
            }else{
                missionText.text = "Voce deve coletar o Dr. Pênis para sair!";
                missionText.gameObject.SetActive(true);
            }

        }else{
            mensagemInteragir.gameObject.SetActive(false);
            missionText.gameObject.SetActive(false);
        }
    }

    IEnumerator Foto()
    {
        carlosDrPenis.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        carlosDrPenis.gameObject.SetActive(false);
        player.GetComponent<academiaBalao>().DrPenis();
    }
}
