using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class close_bardown : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    bool menubar=true;
 private GameObject onoff;
        public GameObject edpopup;
       
 public void OnPointerClick(PointerEventData eventData)
    {
         
     
          
        if(eventData.button == PointerEventData.InputButton.Left)
        {
          
           edpopup.SetActive(false);
         
        }
        

        Debug.Log("Mouse Position : " + eventData.position);
        Debug.Log("Mouse Click Count : " + eventData.clickCount);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       if(eventData.button == PointerEventData.InputButton.Left)
        {
          //Debug.Log("soundplay");   
          
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
      if(eventData.button == PointerEventData.InputButton.Left)
        {
          //Debug.Log("soundplay");   
          
        }
    }
}
