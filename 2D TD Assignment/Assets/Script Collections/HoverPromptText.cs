using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverPromptText : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler 
{
    public GameObject HoverItem;

    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverItem.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HoverItem.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
