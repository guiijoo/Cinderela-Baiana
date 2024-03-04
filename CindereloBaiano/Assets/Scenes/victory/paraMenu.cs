using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class paraMenu : MonoBehaviour
{
    void Update()
    {
        if (!GetComponent<VideoPlayer>().isPlaying) // Verifica se o áudio da intro terminou
            {
                // Ative o Canvas UI do menu
                PlayerPrefs.SetInt("jogou",1);
                SceneManager.LoadScene("Menu");
            }
        
    }
}
