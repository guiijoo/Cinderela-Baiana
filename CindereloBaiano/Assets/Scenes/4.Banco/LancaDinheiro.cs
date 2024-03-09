using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LancaDinheiro : MonoBehaviour
{
    public Transform dinheiro;
    public Transform player;
    public TextMeshProUGUI interacaoTexto;
    public TextMeshProUGUI missionText;
    public int contDin = 0;

    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position)<1.5f)
        {
            if(contDin < 1)
            {
                interacaoTexto.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interacaoTexto.gameObject.SetActive(false);
                    contDin ++;
                }
            }else{
                dinheiro.gameObject.SetActive(true);
                interacaoTexto.gameObject.SetActive(false);
                missionText.text = "Você já roubou tudo! Seu preto!";
                missionText.gameObject.SetActive(true);
            }    
        }else{

        }
    }
}
