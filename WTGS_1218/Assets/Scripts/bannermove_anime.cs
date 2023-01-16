using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class bannermove_anime : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public Animator bannerup;
    public Animator bannerdown;
    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        banner_up();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        banner_down();
    }

    public void banner_up()
    {
        bannerup.SetTrigger("banner");
    }
    public void banner_down()
    {
        bannerdown.SetTrigger("banner_down");
    }
}
