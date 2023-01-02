using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ui_callup_down : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject banner;
    public Animator animator;
    private float time = 0;
    void Start()
    {


    }

    public void OnPointerClick(PointerEventData eventData)
    {




    }
    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("uion", false);
        Debug.Log("up");
        animator.SetBool("uioff", true);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("uion", true);
        Debug.Log("down");
        animator.SetBool("uioff", false);

    }
}
