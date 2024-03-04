using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vicToCredits : MonoBehaviour
{
    public GameObject creditos;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("tocando");
        if(!GetComponent<AudioSource>().isPlaying)
        {
            creditos.SetActive(true);
        }
        
    }
}
