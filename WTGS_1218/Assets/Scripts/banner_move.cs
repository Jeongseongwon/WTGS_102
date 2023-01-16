using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class banner_move : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public GameObject banner;
    public GameObject target;
    public GameObject start;
    private bool flag = false;



    void Update()
    {
        if (flag == true)
        {
            Debug.Log("speeeed");
            banner.GetComponent<RectTransform>().position = Vector3.MoveTowards(target.GetComponent<RectTransform>().position,
       start.GetComponent<RectTransform>().position, 0.1f);
        }
        if (banner.GetComponent<RectTransform>().position == target.GetComponent<RectTransform>().position)
        {
            flag = false;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {


        //flag = true;

        //Debug.Log("move");

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //flag = false;
        //banner.GetComponent<RectTransform>().position = Vector3.MoveTowards(start.GetComponent<RectTransform>().position,
        //target.GetComponent<RectTransform>().position, 3 * Time.deltaTime);
    }
    public void Enter_func()
    {
        flag = true;
    }

    public void Exit_func()
    {
        flag = false;
        banner.GetComponent<RectTransform>().position = Vector3.MoveTowards(start.GetComponent<RectTransform>().position,
        target.GetComponent<RectTransform>().position, 3 * Time.deltaTime);
    }

}
