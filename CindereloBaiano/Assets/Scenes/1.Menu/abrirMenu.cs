using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class abrirMenu : MonoBehaviour
{
    public Canvas canva;
    public bool jogou;
    private void Awake()
    {
        jogou = PlayerPrefs.GetInt("jogou",0) == 1;
        canva.gameObject.SetActive(false);
        if(jogou == false)
        {
            GetComponent<VideoPlayer>().Play();
            GetComponent<AudioSource>().Play(); // Inicia a reprodução do áudio da intro
        }
    }

    void Update()
    {
        if(jogou == false)
        {
            if (!GetComponent<AudioSource>().isPlaying) // Verifica se o áudio da intro terminou
            {
                // Ative o Canvas UI do menu
                canva.gameObject.SetActive(true);
            }
        }else{
            gameObject.SetActive(false);
            canva.gameObject.SetActive(true);
            PlayerPrefs.DeleteKey("jogou");
        }
    }
}