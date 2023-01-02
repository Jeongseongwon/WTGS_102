using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Help_nextbtn : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Text texthover;

    public GameObject prevbtn;

    public GameObject getscript;
    public GameObject page_one;
    public GameObject page_two;
    public GameObject page_three;
    public GameObject page_four;
    private int num = 1;
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (num==1)
        {

            texthover.text = "1번내용";
            getscript.GetComponent<Help_page>().page1();
            prevbtn.GetComponent<help_prevscript>().numcheck();
            num++;
        }
        else if (num == 2)
        {
          
            texthover.text = "2번내용";
            getscript.GetComponent<Help_page>().page2();
            prevbtn.GetComponent<help_prevscript>().numcheck();
            num++;
        }
        else if (num == 3)
        {
           
            texthover.text = "3번내용";
            getscript.GetComponent<Help_page>().page3();
            prevbtn.GetComponent<help_prevscript>().numcheck();
            num++;
        }
        else if (num == 4)
        {
           
            texthover.text = "4번내용";
            getscript.GetComponent<Help_page>().page4();
            prevbtn.GetComponent<help_prevscript>().numcheck();
        }






    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //texthover.text = "";
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        

    }
    public void numcheck2()
    {
        num--;
        print(num);
    }
}
