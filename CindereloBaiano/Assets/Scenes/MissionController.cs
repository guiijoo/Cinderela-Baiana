using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    public bool praCasa;
    public bool banco;
    public bool zebu;
    public bool igreja;
    public bool academia;
    public bool praca;

    void Awake()
    {
        praCasa = PlayerPrefs.GetInt("praCasa", 0) == 1;
        banco = PlayerPrefs.GetInt("banco", 0) ==1;
        zebu = PlayerPrefs.GetInt("zebu", 0) == 1;
        igreja = PlayerPrefs.GetInt("igreja", 0) == 1;
        academia = PlayerPrefs.GetInt("academia", 0) == 1;
        praca = PlayerPrefs.GetInt("praca",0) == 1;
    } 

    void Start()
    {
        praCasa = false;
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

/*

#preciso definir que a missão sera resetada quando clicar em novo jogo, se eu clicar em continuar ele vai continuar de onde ele tava.

#na parte do awake ele ve se a variavel é igual a 1, se for ele altera ela para true;

*/
