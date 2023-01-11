using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_button_audio : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        Manager_audio.instance.Get_click();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Manager_audio.instance.Get_hover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
