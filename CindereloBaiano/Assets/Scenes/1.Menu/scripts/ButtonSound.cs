using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData) {
        GetComponent<AudioSource>().Play();
    }
}
