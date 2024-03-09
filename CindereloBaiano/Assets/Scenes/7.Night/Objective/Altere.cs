using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altere : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
