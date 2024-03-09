using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class comecaVideo : MonoBehaviour
{
    public GameObject video;
    // Start is called before the first frame update
    void Start()
    {
        video.SetActive(false);
    }

    public void iniciaVideo()
    {
        video.SetActive(true);
        gameObject.SetActive(false);
    }

}
