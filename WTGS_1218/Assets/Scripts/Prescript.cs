using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Prescript : MonoBehaviour,IPointerClickHandler
{
    public GameObject boardscript;
    private GameObject nextcall;
    public void OnPointerClick(PointerEventData eventData)
    {
        boardscript.GetComponent<boardcount>().back();
      
          
        if(eventData.button == PointerEventData.InputButton.Left)
        {
          
         
         Text_box_singleton.Instance.Textbox1();
         Text_box_singleton.Instance.play_Clip1();
         Debug.Log("music1");
         
        }
        

        Debug.Log("Mouse Position : " + eventData.position);
        Debug.Log("Mouse Click Count : " + eventData.clickCount);
    }
}
