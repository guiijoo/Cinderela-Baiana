using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public RawImage image;

    public GameObject galeria;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void NovoJogo()
    {
        image.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<AudioSource>().Play();
        Invoke("NovoJogoFunc", 2.5f);
    }

    public void Comecar()
    {
        image.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<AudioSource>().Play();
        Invoke("ComecarFunc", 2.5f);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void NovoJogoFunc()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Narracao");
    }

    public void ComecarFunc()
    {
        SceneManager.LoadScene("Day");
    }

    public void Galeria()
    {
        galeria.SetActive(true);      
    }

    public void SairGaleria()
    {
        galeria.SetActive(false);
    }
}
