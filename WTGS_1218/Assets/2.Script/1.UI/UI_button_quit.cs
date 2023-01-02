using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_button_quit : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        BtnQuit();
    }

    public void BtnQuit()
    {
        Application.Quit();
    }
}
