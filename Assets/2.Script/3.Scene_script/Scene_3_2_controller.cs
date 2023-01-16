using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_3_2_controller : MonoBehaviour
{
    public GameObject PC_Image;
    public GameObject[] PC_Image_Array;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject Study_title;
    int PostCount;

    // Start is called before the first frame update
    void Start()
    {

        //PC_Image_Array = PC_Image.gameObject.GetComponentsInChildren<Transform>();
        // PC_Image_Array = GameObject.FindGameObjectsWithTag("PC_Sprite");
        PC_Image.SetActive(false);

        Invoke("Startact", 2f);    // 5초 뒤에 해당 오브젝트 화면에 투사
        Invoke("PC_ON", 10f);    // 5초 뒤에 해당 오브젝트 화면에 투사
    }
    private void Startact() //중간 평가용으로 수정
    {
        Study_title.SetActive(true);
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
    }
    private void PC_ON()
    {
        Study_title.GetComponent<Animation>().Play("Intro_2_animation(off)");

        PC_Image.SetActive(true);
        for (int i = 0; i < PC_Image_Array.Length; i++)
        {
            PC_Image_Array[i].gameObject.SetActive(false);
        }
        PC_Image_Array[0].gameObject.SetActive(true);
        
    }
    // Update is called once per frame
    void Update()
    {
        int BtnCount = gameObject.GetComponent<Script_controller>().btnCount;
        if (PostCount != BtnCount)
            for (int i = 0; i < PC_Image_Array.Length; i++)
            {
                PC_Image_Array[i].gameObject.SetActive(false);
                
            }
        //PC_Image_Array[0].gameObject.SetActive(true);
        if (BtnCount == 1)
        {
           // Startact();
        }
        else if (BtnCount == 2)
        {
            Debug.Log("check_2");
        }
        PC_Image_Array[BtnCount].SetActive(true);
        PostCount = BtnCount;
    }
}
