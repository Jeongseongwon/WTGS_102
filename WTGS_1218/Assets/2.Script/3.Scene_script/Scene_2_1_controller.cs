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
    public GameObject Graph_velocity;
    public GameObject Graph_power;
    public GameObject Data_velocity;
    public GameObject Data_power;


    //2-1 Text
    [Header("===== Text =====")]
    public GameObject Angle_pitch_target;
    public GameObject Angle_pitch;
    public GameObject Velocity_wind;
    public GameObject Power;

    //Value
    private float Value_Angle_pitch;
    private float Value_Angle_pitch_target;
    private float Value_Velocity_wind;
    private float Value_Power;

    private int BtnCount;
    private float Value_max = 0;

    int PostCount;
    private bool flag = true;
    private bool flag_num = false;
    // Start is called before the first frame update
    void Start()
    {
        Value_Angle_pitch = 30;
        Value_Angle_pitch_target = 0;
        Value_Velocity_wind = 100;
        Value_Power = 100;

        StartCoroutine(Startact());
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
        BtnCount = gameObject.GetComponent<Script_controller>().btnCount;

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
                StartCoroutine(Refresh_text_value());
            }
            else if (BtnCount == 8)
            {
                Emergency.SetActive(true);
                Change_graph_number(Data_velocity, 3);

            }
            else if (BtnCount == 9)
            {
                Green_button_1.SetActive(false);
                Green_button_2.SetActive(false);
                red_button_1.SetActive(true);
                red_button_2.SetActive(true);
                StartCoroutine(Alert_value());  //목표 피치값 변경
                Change_graph_number(Data_power, 100);
                //타겟 : 0 /현재 : 30

            }
            else if (BtnCount == 10)
            {
                START();
                StartCoroutine(Alert_value());  //목표 피치값 변경
                                                //풍속 값 변경 , 이 둘의 속도는 비슷하게 제어가 되는 걸로
                Change_value(45);
                Change_graph_number(Data_velocity, 12);
            }
            else if (BtnCount == 11)
            {
                //Change_graph_number(Data_power, 100);//데이터 파워는 피치각 조절함에 따라 지속적으로 변경이 필요함

                Change_graph_number(Data_velocity, 25);
            }
            else if (BtnCount == 12)
            {
                StartCoroutine(Alert_value());
                Change_value(90);
            }

            else if (BtnCount == 13)
            {
                Change_graph_number(Data_velocity, 9);
                StartCoroutine(Alert_value());
                Change_value(30);
            }
            PC_Image_Array[BtnCount].SetActive(true);
            PostCount = BtnCount;
            flag = false;
            Debug.Log("FALSE");
        }

        if (flag_num == true)
        {
            Value_Angle_pitch_target = Mathf.Lerp(Value_Angle_pitch_target, Value_max, Time.deltaTime);

            if (Value_Angle_pitch_target == Value_max)
            {
                Debug.Log("Done");
                flag_num = false;
            }
        }

        //데이터 전용 타이머?
    }
    IEnumerator Startact() //중간 평가용으로 수정
    {
        yield return new WaitForSeconds(2.0f);
        Study_title_Intro_2.SetActive(true);
        Study_title_Intro_2.GetComponent<Animation>().Play("Intro_2_animation(on)");
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        yield break;
    }


    private void Change_value(float max)
    {
        flag_num = true;
        Value_max = max;
    }

    private void Change_graph_number(GameObject data,float num)
    {
        data.GetComponent<StreamingGraph>().min = (num - 0.5f) * 0.05f;
        data.GetComponent<StreamingGraph>().max = (num + 0.5f) * 0.05f;
    }
    IEnumerator Alert_value()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            //5초 정도 시간이 지나고 나면, 타이머 설정, 타이머 리셋
            if (Value_Angle_pitch_target - Value_Angle_pitch > 20)
            {
                Alert_message_caution.SetActive(false);
                Alert_message_danger.SetActive(true);
            }
            else if (Value_Angle_pitch_target - Value_Angle_pitch > 10)
            {
                Alert_message_caution.SetActive(true);
                Alert_message_danger.SetActive(false);
            }
            else if (Value_Angle_pitch_target - Value_Angle_pitch <= 3 && Value_Angle_pitch_target - Value_Angle_pitch >= -3)
            {
                Debug.Log(Value_Angle_pitch_target - Value_Angle_pitch);
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
    IEnumerator Refresh_text_value()
    {
        while (true)
        {
            Angle_pitch_target.GetComponent<Text>().text = Value_Angle_pitch_target.ToString("F1");
            Angle_pitch.GetComponent<Text>().text = Value_Angle_pitch.ToString("F1");
            //Velocity_wind.GetComponent<Text>().text = Value_Velocity_wind.ToString("F1");
            //Power.GetComponent<Text>().text = Value_Power.ToString("F1");
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void Set_add_pitch()
    {
        Value_Angle_pitch += 5;
        if (BtnCount == 9)
        {
            Change_graph_number(Data_power, ((30-Value_Angle_pitch) / 30) * 1000);
        }
        else if (BtnCount == 10)
        {
            Change_graph_number(Data_power, 1000 + (Value_Angle_pitch / 45) * 1100);
        }
        else if (BtnCount == 12)
        {
            Change_graph_number(Data_power, 2500 - ( (Value_Angle_pitch-45) / 45) * 400);
        }
        else if (BtnCount == 13)
        {
            Change_graph_number(Data_power, 1800 + ( (90-Value_Angle_pitch) / 60) * 400);
        }
    }

    public void Set_reduce_pitch()
    {
        Value_Angle_pitch -= 5;
        Value_Power = 2100;
        if (BtnCount == 9)
        {
            Change_graph_number(Data_power, ((30 - Value_Angle_pitch) / 30) * 1000);
        }
        else if (BtnCount == 10)
        {
            Change_graph_number(Data_power, 1000 + (Value_Angle_pitch / 45) * 1100);
        }
        else if (BtnCount == 12)
        {
            Change_graph_number(Data_power, 2500 - ((Value_Angle_pitch - 45) / 45) * 400);
        }
        else if (BtnCount == 13)
        {
            Change_graph_number(Data_power, 1800 + ((90 - Value_Angle_pitch) / 60) * 400);
        }
    }

    public void Stop()
    {
        Value_Angle_pitch = 30;
        Value_Angle_pitch_target = 0;
        Value_Velocity_wind = 0;
        Value_Power = 0;
        Wind_particle.SetActive(false);
        Graph_velocity.SetActive(false);
        Graph_power.SetActive(false);
        Data_power.GetComponent<StreamingGraph>().min = 0;
        Data_power.GetComponent<StreamingGraph>().max = 0;
        Data_velocity.GetComponent<StreamingGraph>().min = 0;
        Data_velocity.GetComponent<StreamingGraph>().max = 0;
    }

    public void START()
    {
        Wind_particle.SetActive(true);
        Graph_velocity.SetActive(true);
        Graph_power.SetActive(true);
    }

    //8, 시작 누르면 9 에서 풍속 3m/s 상승
    //9, 브레이크 해제하면 10에서 생산전력량 일부 상승 시작
    //10, 풍속 바로 15m/s까지 상승 및 버튼 클릭함에 따라 전력 생산량 상승
    //11, 풍속 바로 20m/s까지 상승
    //12, 버튼 클릭함에 따라 전력 생산량 하강
    //14, 풍속 바로 10m/s까지 하강, 전력 생산량 하강 및 버튼 클릭함에 따라 전력 생산량 상승



}
