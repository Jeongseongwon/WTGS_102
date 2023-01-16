using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class btnrollover : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public float sizeInit;
    public float sizeUP;

    //public GameObject tooltip;
    private GameObject tooltip_text;

    void Start()
    {
        Debug.Log(this.GetComponent<Transform>().childCount);
        if(this.GetComponent<Transform>().childCount != 0)
        {
            tooltip_text = this.GetComponent<Transform>().GetChild(0).gameObject;
        }
    }
    public void OnPointer()
    {
        ScaleUP();
        TooltipEnable();
    }
    public void OFFPointer()
    {
        ScaleInit();
        TooltipDisable();
    }
    public void ScaleUP()
    {
        RectTransform rectTran = gameObject.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sizeUP);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sizeUP);
    }
    public void ScaleInit()
    {
        RectTransform rectTran = gameObject.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sizeInit);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sizeInit);
    }
    public void TooltipEnable()
    {
        //tooltip.SetActive(true);
        tooltip_text.SetActive(true);

    }
    public void TooltipDisable()
    {
        //tooltip.SetActive(false);
        tooltip_text.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {


        }

        Debug.Log("Mouse Position : " + eventData.position);
        Debug.Log("Mouse Click Count : " + eventData.clickCount);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("soundplay");
            OFFPointer();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnPointer();
            Debug.Log("soundplay");
        }
    }
}
