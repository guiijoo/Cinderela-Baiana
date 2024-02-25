using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeuCerto : MonoBehaviour
{

        float playerPosX = PlayerPrefs.GetFloat("playerPosX");
        float playerPosY = PlayerPrefs.GetFloat("playerPosY");
        float playerPosZ = PlayerPrefs.GetFloat("playerPosZ");
        
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(Certo());
        GetComponent<MissionController>().praCasa = true;
    }

    private IEnumerator Certo()
    {
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("praCasa", 0);
        SceneManager.LoadScene("Day");
    }
}
