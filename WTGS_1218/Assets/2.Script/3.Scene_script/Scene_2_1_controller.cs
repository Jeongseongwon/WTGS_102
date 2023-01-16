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
    [Header("===== Gameobject =====")]
    public GameObject Wind_particle;
    public GameObject Blade_1;
    public GameObject Blade_2;
    public GameObject Blade_3;
    public GameObject WTGS_Panel;
    public GameObject Camera;
    public GameObject Subcamera;

    //2-1 panel
    [Header("===== Panel obejct =====")]
    public GameObject Green_button_1;
    public GameObject Green_button_2;
    public GameObject red_button_1;
    public GameObject red_button_2;
    public GameObject Emergency;
    public GameObject Alert_message_caution;
    public GameObject Alert_message_danger;


    //2-1 Text
    [Header("===== Text =====")]
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
        Value_Angle_pitch = 100;
        Value_Angle_pitch_target = 100;
        Value_Velocity_wind = 100;
        Value_Power = 100;
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
                //초기화
                Subcamera.SetActive(false);
                WTGS_Panel.SetActive(false);
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
            else if (BtnCount==6)
            {
                Emergency.SetActive(false);
            }
            else if (BtnCount == 7)
            {
                //초기화
                Green_button_1.SetActive(true);
                Green_button_2.SetActive(true);
                red_button_1.SetActive(false);
                red_button_2.SetActive(false);
                StartCoroutine(Alert_value());


                Emergency.SetActive(true);
            }
            else if (BtnCount == 8)
            {
                Green_button_1.SetActive(false);
                Green_button_2.SetActive(false);
                red_button_1.SetActive(true);
                red_button_2.SetActive(true);
                StartCoroutine(Alert_value());
                Value_Angle_pitch_target = 45;  //그 근처 값으로 바뀌게끔 만들어야할듯
                Value_Angle_pitch = 20;  //그 근처 값으로 바뀌게끔 만들어야할듯
            }
            else if (BtnCount == 10)
            {
                StartCoroutine(Alert_value());
                Value_Angle_pitch_target = 90;
                Value_Angle_pitch_target = 60;
            }

            else if (BtnCount == 12)
            {
                StartCoroutine(Alert_value());
                Value_Angle_pitch_target = 30;
                Value_Angle_pitch_target = 35;
            }
            PC_Image_Array[BtnCount].SetActive(true);
            PostCount = BtnCount;
            flag = false;
            Debug.Log("FALSE");
        }

        //데이터 전용 타이머?
    }

    IEnumerator  Alert_value()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            //5초 정도 시간이 지나고 나면, 타이머 설정, 타이머 리셋
            if (Value_Angle_pitch_target - Value_Angle_pitch > 20)
            {
                //주의 메시지 활성화
                Alert_message_caution.SetActive(true);
                Alert_message_danger.SetActive(false);
            }
            else if (Value_Angle_pitch_target - Value_Angle_pitch > 10)
            {
                //주의 메시지 활성화
                Alert_message_caution.SetActive(false);
                Alert_message_danger.SetActive(true);
            }
            else if (Value_Angle_pitch_target - Value_Angle_pitch <= 3 && Value_Angle_pitch_target - Value_Angle_pitch <= -3)
            {
                gameObject.GetComponent<Script_controller>().NextBtn();
                Alert_message_caution.SetActive(false);
                Alert_message_danger.SetActive(false);
                yield break;
            }
        }
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
    private void Refresh_text_value()
    {
        Angle_pitch_target.GetComponent<Text>().text = Value_Angle_pitch_target.ToString();
        Angle_pitch.GetComponent<Text>().text = Value_Angle_pitch.ToString();
        Velocity_wind.GetComponent<Text>().text = Value_Velocity_wind.ToString();
        Power.GetComponent<Text>().text = Value_Power.ToString();
    }
    public void Set_add_pitch()
    {
        Value_Angle_pitch+=5;
    }

    public void Set_reduce_pitch()
    {
        Value_Angle_pitch-=5;
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
