using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sair : MonoBehaviour
{
    public Transform player;

    public TextMeshProUGUI interagir;
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position)<1.5f)
        {
            interagir.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Day");
            }
        }else{
            interagir.gameObject.SetActive(false);
        }
        
    }
}
