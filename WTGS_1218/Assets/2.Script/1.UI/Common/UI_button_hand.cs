using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_button_hand : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
   
    // 0 : Arrow
    // 1 : Hand
    //
    //
    //
    //

    public void OnPointerClick(PointerEventData eventData)
    {
        Cursor.SetCursor(Manager_image.instance.Get_arrow_image(), Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(Manager_image.instance.Get_hand_image(), Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(Manager_image.instance.Get_arrow_image(), Vector2.zero, CursorMode.ForceSoftware);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    //void Update()
    //{

    //}
}
