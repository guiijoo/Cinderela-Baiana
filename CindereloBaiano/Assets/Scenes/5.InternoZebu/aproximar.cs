using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class aproximar : MonoBehaviour
{
    public Transform coca;
    public Transform pao;
    public TextMeshProUGUI mensageInteracao;
    public GameObject missionController;

    void Update()
    {
        if(Vector3.Distance(transform.position, coca.transform.position)<2f)
        {
            mensageInteracao.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("apertou");
                missionController.GetComponent<MissionCompleteZebu>().coca = true;
                coca.gameObject.SetActive(false);
            }
        }else if(Vector3.Distance(transform.position, pao.transform.position)<2f){
                mensageInteracao.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    missionController.GetComponent<MissionCompleteZebu>().pao = true;
                    pao.gameObject.SetActive(false);
                }
        }
    }
}
