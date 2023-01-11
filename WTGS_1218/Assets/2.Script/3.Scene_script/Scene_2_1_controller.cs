using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_2_1_controller : MonoBehaviour
{
    public GameObject PC_Image;
    public GameObject[] PC_Image_Array;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject Study_title_Intro_2;

    //2-1 Gameobject
    public GameObject Wind_particle;
    public GameObject Blade_1;
    public GameObject Blade_2;
    public GameObject Blade_3;
    public GameObject WTGS_Panel;
    public GameObject Camera;
    public GameObject Subcamera;

    //Text
    public GameObject Angle_pitch_target;
    public GameObject Angle_pitch;
    public GameObject Velocity_wind;
    public GameObject Power;

    //Value
    private int Value_Angle_pitch;
    private int Value_Angle_pitch_target;
    private int Value_Velocity_wind;
    private int Value_Power;

    int PostCount;
    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        Value_Angle_pitch=100;
        Value_Angle_pitch_target= 100; 
        Value_Velocity_wind= 100;
        Value_Power= 100;
        //PC_Image_Array = PC_Image.gameObject.GetComponentsInChildren<Transform>();
        // PC_Image_Array = GameObject.FindGameObjectsWithTag("PC_Sprite");
        //PC_Image.SetActive(false);

        Invoke("Startact", 2f);    // 5초 뒤에 해당 오브젝트 화면에 투사
        //Invoke("PC_ON", 10f);    // 5초 뒤에 해당 오브젝트 화면에 투사
    }
    private void Startact() //중간 평가용으로 수정
    {
        Study_title_Intro_2.SetActive(true); 
        Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(on)");
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
    }
    private void PC_ON()
    {
        Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");

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
        Refresh_text_value();
        int BtnCount = gameObject.GetComponent<Script_controller>().btnCount;

        if (PostCount != BtnCount)
        {
            
            PC_Image_Array[PostCount].gameObject.SetActive(false);
            flag = true;
            Debug.Log("TRUE");
        }
            //for (int i = 0; i < PC_Image_Array.Length; i++)
//{
            //}
        if (flag == true)
        {
            if (BtnCount == 0)
            {
                
              
            }
            if (BtnCount == 1)
            {
                Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(off)");
            }
            else if (BtnCount == 2)
            {
                //카메라 움직이는거, 옆에 패널 애니메이션 추가
                Camera.GetComponent<Animation>().Play("Camera_move(intro,2_1)");
                Subcamera.SetActive(true);
                WTGS_Panel.SetActive(true);
                Debug.Log("check_2");
            }
            PC_Image_Array[BtnCount].SetActive(true);
            PostCount = BtnCount;
            flag = false;
            Debug.Log("FALSE");
        }
       
        //데이터 전용 타이머?
    }

    public void Rotate_blade_up()
    {
        Blade_1.GetComponent<Transform>().Rotate(new Vector3(0, 10, 0));
        Blade_2.GetComponent<Transform>().Rotate(new Vector3(0, 10, 0));
        Blade_3.GetComponent<Transform>().Rotate(new Vector3(0, 10, 0));
    }
    public void Rotate_blade_down()
    {
        Blade_1.GetComponent<Transform>().Rotate(new Vector3(0, -10, 0));
        Blade_2.GetComponent<Transform>().Rotate(new Vector3(0, -10, 0));
        Blade_3.GetComponent<Transform>().Rotate(new Vector3(0, -10, 0));
    }
    public void Refresh_text_value()
    {
        Angle_pitch_target.GetComponent<Text>().text= Value_Angle_pitch_target.ToString();
        Angle_pitch.GetComponent<Text>().text = Value_Angle_pitch.ToString();
        Velocity_wind.GetComponent<Text>().text = Value_Velocity_wind.ToString();
        Power.GetComponent<Text>().text = Value_Power.ToString();
    }
    public void Set_add_pitch()
    {
        Value_Angle_pitch++;
    }

    public void Set_reduce_pitch()
    {
        Value_Angle_pitch--;
    }

    public void Stop()
    {
        Value_Angle_pitch = 0;
        Value_Angle_pitch_target = 0;
        Value_Velocity_wind = 0;
        Value_Power = 0;
        //1초에 한 번씩 함수 호출?
    }

    public void START()
    {
        //바람 효과 온, 풍속 데이터 증가 시작
    }
    //첫번째 화면이 인트로_2 -> 스크립트 1번
    //두번째 화면이 인트로 없어지면서 -> 학습 시작
}
