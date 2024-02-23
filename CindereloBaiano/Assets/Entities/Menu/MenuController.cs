using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Comecar()
    {
        SceneManager.LoadScene("Night");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
