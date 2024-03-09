using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMissionController : MonoBehaviour
{

    private GameObject player;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        float playerPosX = PlayerPrefs.GetFloat("playerPosX");
        float playerPosY = PlayerPrefs.GetFloat("playerPosY");
        float playerPosZ = PlayerPrefs.GetFloat("playerPosZ");
        if(playerPosX != 0)
        {
            Vector3 playerPosition = new Vector3(playerPosX, playerPosY, playerPosZ);
            player.transform.position = playerPosition;
        }
    }

    void Update()
    {
        
    }


}
