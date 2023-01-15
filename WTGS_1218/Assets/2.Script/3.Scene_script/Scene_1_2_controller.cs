using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HighlightPlus;

public class Scene_1_2_controller : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Main_object;
    public GameObject Scriptbox;
    public GameObject Top_navigation;
    public GameObject Wind_particle;
    public GameObject Study_title;

    private Text text;
    bool toggle = true;
    int nowCount;
    int postCount;
    bool Prev_Status = false;
    private int phase = 0;

    private List<string> anim_list = new List<string>();
    // Start is called before the first frame update

    private Animation Anim;
    public GameObject Object_1_blade1;
    public GameObject Object_2_blade2;
    public GameObject Object_3_blade3;
    public GameObject Object_4_Nacelle;
    public GameObject Object_5_Tower;
    public GameObject Object_6_Rotor;
    public GameObject Object_7_Shaft;
    public GameObject Object_8_Hub;
    public GameObject Object_9_Pitch;
    public GameObject Object_10_Spinner;
    public GameObject Object_11_Mainshaft;
    public GameObject Object_12_Yaw;
    public GameObject Object_13_Gearbox;
    public GameObject Object_14_Generator;

    void Start()
    {
        Anim = Main_object.GetComponent<Animation>();

        Camera.GetComponent<Camera_movement>().enabled = false;
        StartCoroutine(Startact());
        Object_Col_Off_ALL();
    }
    IEnumerator Startact() //중간 평가용으로 수정
    {
        yield return new WaitForSeconds(3.0f);
        Study_title.SetActive(true);
        Scriptbox.GetComponent<Animation>().Play("bannerup(1220)");
        Top_navigation.GetComponent<Animation>().Play("TN_intro_down");
        yield break;
    }

    void Act1()
    {
        if (Prev_Status == true)
        {
            Prev_Status = false;
            //카메라, 발전기 위치 재설정

        }
        Object_Col_Off_ALL();
        Object_Col_on(Object_1_blade1);
        Object_Col_on(Object_2_blade2);
        Object_Col_on(Object_3_blade3);
        Object_Col_on(Object_4_Nacelle);
        Object_Col_on(Object_5_Tower);
        Object_Col_on(Object_6_Rotor);

        Camera.GetComponent<Camera_movement>().enabled = true;
        Study_title.GetComponent<Animation>().Play("Intro_2_animation(off)");
        Anim.Play("1_WTG_rotation");
        Wind_particle.SetActive(true);
        //인트로 2
        Debug.Log("act1");
    }
    //블레이드
    void Act2()
    {
        if (Prev_Status == true)
        {
            Prev_Status = false;
            //Camera.GetComponent<Camera_movement>().act2();
        }

        //this.GetComponent<NarrationController>().Audio.clip = this.GetComponent<NarrationController>().AudioFiles[1];


        Debug.Log("act2");
    }
    void Act3()
    {
        StartCoroutine(Highlight_onoff(Object_1_blade1));
        StartCoroutine(Highlight_onoff(Object_2_blade2));
        StartCoroutine(Highlight_onoff(Object_3_blade3));

        Object_Col_Off_ALL();

        Object_Col_on(Object_1_blade1);
        Object_Col_on(Object_2_blade2);
        Object_Col_on(Object_3_blade3);
        Wind_particle.SetActive(false);
        Camera.GetComponent<Camera_movement>().act1();
        Anim.Stop();
        Anim.Play("3_WTG_blade_move");
        Debug.Log("act3");

    }
    void Act4()
    {
        Object_Col_on(Object_6_Rotor);


        Wind_particle.SetActive(true);
        Camera.GetComponent<Camera_movement>().act2();
        Anim.Play("3_WTG_blade_move(return)");
        Debug.Log("act4");

    }
    void Act5()
    {
        Object_Col_Off_ALL();
        Object_6_Rotor.GetComponent<MeshCollider>().enabled = true;
        Object_8_Hub.GetComponent<MeshCollider>().enabled = true;
        Object_9_Pitch.GetComponent<MeshCollider>().enabled = true;
        Object_10_Spinner.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act3();
        Anim.Play("4_WTG_rotor_move");

        Debug.Log("act5");


        Object_Col_Off_ALL();
        Object_8_Hub.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act4();
        Debug.Log("act5");
    }
    void Act6()
    {
        Object_Col_Off_ALL();
        Object_9_Pitch.GetComponent<MeshCollider>().enabled = true;
        Anim.Play("5_WTG_blade_pitch");
        Debug.Log("act6");
    }
    void Act7()
    {
        //나셀 내부부품 툴팁 추가하기
        Object_Col_Off_ALL();
        Object_11_Mainshaft.GetComponent<MeshCollider>().enabled = true;
        Object_12_Yaw.GetComponent<MeshCollider>().enabled = true;
        Object_13_Gearbox.GetComponent<MeshCollider>().enabled = true;
        Object_14_Generator.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act5();
        Anim.Play("6_WTG_blade_pitch(return)+nacelle_open");
        Debug.Log("act7");
    }
    void Act8()
    {
        //나셀 내부부품 툴팁 추가하기
        Object_Col_Off_ALL();
        Object_12_Yaw.GetComponent<MeshCollider>().enabled = true;
        Camera.GetComponent<Camera_movement>().act6();
        Anim.Play("7_WTG_Nacelle_rotation");
        Debug.Log("act8");
    }
    void Act9()
    {

    }
    void Act11()
    {

    }
    void Act13()
    {

    }
    void Act14()
    {

    }
    void Act15()
    {


    }

    //애니메이션 재생하면서 오브젝트 물리엔진 일시정지 및 활성화
    //void KineticDisable()
    //{
    //    Transform AllMetalball = Metalball.GetComponentInChildren<Transform>();
    //    foreach (Transform child in AllMetalball)
    //    {
    //        child.GetComponent<Rigidbody>().isKinematic = true;
    //    }
    //}
    //void KineticEnable()
    //{
    //    Transform AllMetalball = Metalball.GetComponentInChildren<Transform>();
    //    foreach (Transform child in AllMetalball)
    //    {
    //        child.GetComponent<Rigidbody>().isKinematic = false;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        BtnCountToggle();
        if (toggle)
        {
            Call_act(nowCount);
            toggle = false;
        }
    }

    void Call_act(int btncount)
    {
        if (btncount == 0)
        {

        }
        else if (btncount == 1)
        {
            Act1();
        }
        else if (btncount == 2)
        {
            Act2();
        }
        else if (btncount == 3)
        {
            Act3();
        }
        else if (btncount == 4)
        {
            Act4();
        }
        else if (btncount == 5)
        {
            Act5();
        }
        else if (btncount == 6)
        {
            Act6();
        }
        else if (btncount == 7)
        {
            Act7();
        }
        else if (btncount == 8)
        {
            Act8();
        }
        else if (btncount == 9)
        {
            //Act9();
        }
        else if (btncount == 10)
        {
            //Act10();
        }
        else if (btncount == 11)
        {
            //Act11();
        }


    }
    void BtnCountToggle()
    {
        nowCount = gameObject.GetComponent<Script_controller>().btnCount;
        if (nowCount != postCount)
        {
            toggle = true;

            if (nowCount < postCount)
            {
                Prev_Status = true;
            }

        }
        postCount = nowCount;
    }
    private void Object_Col_Off_ALL()
    {
        Object_1_blade1.GetComponent<MeshCollider>().enabled = false;
        Object_2_blade2.GetComponent<MeshCollider>().enabled = false;
        Object_3_blade3.GetComponent<MeshCollider>().enabled = false;
        Object_4_Nacelle.GetComponent<MeshCollider>().enabled = false;
        Object_5_Tower.GetComponent<MeshCollider>().enabled = false;
        Object_6_Rotor.GetComponent<MeshCollider>().enabled = false;
        Object_7_Shaft.GetComponent<MeshCollider>().enabled = false;
        Object_8_Hub.GetComponent<MeshCollider>().enabled = false;
        Object_9_Pitch.GetComponent<MeshCollider>().enabled = false;
        Object_10_Spinner.GetComponent<MeshCollider>().enabled = false;
        Object_11_Mainshaft.GetComponent<MeshCollider>().enabled = false;
        Object_12_Yaw.GetComponent<MeshCollider>().enabled = false;
        Object_13_Gearbox.GetComponent<MeshCollider>().enabled = false;
        Object_14_Generator.GetComponent<MeshCollider>().enabled = false;
    }

    //** 툴팁 키고 끄는 기능으로 사용
    private void Object_Col_on(GameObject obj)
    {
        obj.GetComponent<MeshCollider>().enabled = true;
    }

    //** 하이라이트 시간 동안 키고 끄는 기능으로 사용

    IEnumerator Highlight_onoff(GameObject obj) //중간 평가용으로 수정
    {
        obj.GetComponent<HighlightEffect>().highlighted = true;
        yield return new WaitForSeconds(3.0f);
        obj.GetComponent<HighlightEffect>().highlighted = false;
        yield break;
    }

}
