using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class popuihoverscript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Text texthover;
    [TextArea]
    public string textthis;
    private GameObject Tooltip;
    void Start()
    {
        Tooltip = GameObject.FindGameObjectWithTag("Tooltip");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Tooltip.transform.GetChild(0).gameObject.SetActive(false);
        Tooltip.GetComponent<Tooltip>().Change_text(" ");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exxit");
        Tooltip.transform.GetChild(0).gameObject.SetActive(false);
        Tooltip.GetComponent<Tooltip>().Change_text(" ");
        //texthover.text = "";
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter");
        //texthover.text = textthis;
        Tooltip.transform.GetChild(0).gameObject.SetActive(true);
        Tooltip.GetComponent<Tooltip>().Change_text(textthis);

    }
}
