using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help_page : MonoBehaviour
{
    public GameObject page_one;
    public GameObject page_two;
    public GameObject page_three;
    public GameObject page_four;

    public GameObject togle1;
    public GameObject togle2;
    public GameObject togle3;
    public GameObject togle4;
    public Text pagecount;

    public void page1()
    {
        pagecount.text = "1/4";
        page_one.SetActive(true);
        page_two.SetActive(false);
        page_three.SetActive(false);
        page_four.SetActive(false);


        togle1.SetActive(true);
        togle2.SetActive(false);
        togle3.SetActive(false);
        togle4.SetActive(false);
    }
    public void page2()
    {
        pagecount.text = "2/4";
        page_one.SetActive(false);
        page_two.SetActive(true);
        page_three.SetActive(false);
        page_four.SetActive(false);


        togle1.SetActive(false);
        togle2.SetActive(true);
        togle3.SetActive(false);
        togle4.SetActive(false);
    }
    public void page3()
    {
        pagecount.text = "3/4";
        page_one.SetActive(false);
        page_two.SetActive(false);
        page_three.SetActive(true);
        page_four.SetActive(false);


        togle1.SetActive(false);
        togle2.SetActive(false);
        togle3.SetActive(true);
        togle4.SetActive(false);
    }
    public void page4()
    {
        pagecount.text = "4/4";
        page_one.SetActive(false);
        page_two.SetActive(false);
        page_three.SetActive(false);
        page_four.SetActive(true);


        togle1.SetActive(false);
        togle2.SetActive(false);
        togle3.SetActive(false);
        togle4.SetActive(true);
    }
}
