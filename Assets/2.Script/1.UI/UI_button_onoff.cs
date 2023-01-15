using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_button_onoff : MonoBehaviour, IPointerClickHandler
{
    public GameObject Change_button;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    public void OnPointerClick(PointerEventData eventData)
    {
        Change_button.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
