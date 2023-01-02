using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class banner_anime_end : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
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
    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    animator.SetBool("up_banner", true);
    //    Debug.Log("up");
    //    animator.SetBool("down_banner", false);
    //}
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        animator.SetBool("up_banner", true);
        Debug.Log("up");
        animator.SetBool("down_banner", false);
    }

}
