using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    public bool praCasa;
    public bool banco= false;
    public bool zebu= false;
    public bool igreja= false;
    public bool academia= false;
    public bool praca= false;

    void Start()
    {
        int comparador = PlayerPrefs.GetInt("praCasa");
        if(comparador == 1)
        {
            praCasa = true;
            Debug.Log("mudou pra true");
        }else{
            Debug.Log("não mudou");
        }
    }
}
