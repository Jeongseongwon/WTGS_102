using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class boardchange : MonoBehaviour, IPointerClickHandler
{
    public GameObject nowboard;
    public GameObject nextboard;

    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            nowboard.SetActive(false);
            nextboard.SetActive(true);

        }

        Debug.Log("Mouse Position : " + eventData.position);
        Debug.Log("Mouse Click Count : " + eventData.clickCount);
    }
}
