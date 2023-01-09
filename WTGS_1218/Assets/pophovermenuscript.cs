using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pophovermenuscript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Text texthover;
    [TextArea]
    public string textthis;

    public void OnPointerClick(PointerEventData eventData)
    {




    }
    public void OnPointerExit(PointerEventData eventData)
    {
        texthover.text = "";
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        texthover.text = textthis;

    }
}
