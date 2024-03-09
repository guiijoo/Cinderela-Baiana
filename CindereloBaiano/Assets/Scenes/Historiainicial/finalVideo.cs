using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalVideo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {  
        if(!GetComponent<AudioSource>().isPlaying)
        {
        SceneManager.LoadScene("Day");
        }
    }
}
