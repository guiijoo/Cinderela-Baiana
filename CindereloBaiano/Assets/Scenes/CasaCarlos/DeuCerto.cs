using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeuCerto : MonoBehaviour
{

        float playerPosX = PlayerPrefs.GetFloat("playerPosX");
        float playerPosY = PlayerPrefs.GetFloat("playerPosY");
        float playerPosZ = PlayerPrefs.GetFloat("playerPosZ");
    // Start is called before the first frame update
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
        PlayerPrefs.SetFloat("playerPosX", playerPosX);
        PlayerPrefs.SetFloat("playerPosY", playerPosY);
        PlayerPrefs.SetFloat("playerPosZ", playerPosZ);
        // PlayerPrefs.SetInt("praCasa", 1);
        SceneManager.LoadScene("Day");
    }
}
