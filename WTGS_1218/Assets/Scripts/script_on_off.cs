using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class script_on_off : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler

{
    bool menubar = true;
    public GameObject onoff;
    public GameObject edpopup;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (menubar == true)
            {

                onoff.SetActive(false);
                menubar = false;

            }
            else
            {

                onoff.SetActive(true);
                menubar = true;
            }

        }
       
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("soundplay");
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
           // Debug.Log("soundplay");
        }
    }
}
