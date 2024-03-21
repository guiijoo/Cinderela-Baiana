using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject telaGO;
    void Update()
    {
        if(!GetComponent<AudioSource>().isPlaying)
        {
            telaGO.SetActive(true);
        }
    }
}
