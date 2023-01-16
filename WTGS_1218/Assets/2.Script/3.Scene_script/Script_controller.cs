using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Script_controller : MonoBehaviour
{
    
    public int btnCount = 0;
    public string Scene_number; //해단 씬 스크립트 파일 불러오기 예)1_2

    public Text text;           //스크립트 나타는 박스
    //public GameObject TextPanel;  //애니메이션 용, 추가 필요 

    public bool FadeOut = false;
    GameObject Fader;
    float script_time_now;


    private float Time_limit;
    private bool status_UI_script_auto;
    private bool First_status_UI;

    private int Max_num_script=0;
    private int Num_script;

    public List<string> textList = new List<string>();
    public GameObject scene_controller;
    

    // Start is called before the first frame update
    void Start()
    {
        Read_txt();
        status_UI_script_auto = false;
        First_status_UI = true;

        Time_limit = 20f;
        script_time_now = Time_limit;

        //if (Manager_audio.instance != null) , BGM �κ�

        //scene_controller = 
        if (Manager_scene.instance != null)
        {
            status_UI_script_auto = Manager_scene.instance.Status_Check_script_auto_over();

        }
        //Fader = GameObject.Find("Fader");   
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager_scene.instance!= null)
        {
            status_UI_script_auto = Manager_scene.instance.Status_Check_script_auto_over();
           
        }
        if (status_UI_script_auto == true && First_status_UI == true)
        {
            Timer_set();
            First_status_UI = false;
            //Debug.Log("auto button timer start" + script_time_now);
        }
        if (status_UI_script_auto == true)
        {
            script_time_now -= Time.deltaTime;
            if (script_time_now < 0)
            {
                NextBtn();
                //Debug.Log("timer done");
            }
        }
    }

    public void NextBtn()
    {
        Debug.Log("NEXTBUTTON");
        if (status_UI_script_auto == true)
        {
            Timer_set();
        }
        btnCount++;
        ScriptCount();
        this.GetComponent<Narration_controller>().EffectReset();    //next button 이펙트 추가용
        
        //if (TextPanel != null)
        ////next, prev ������ �� �ִϸ��̼� ��� �Ǵ� �κ�
        //{
        //    TextPanel.GetComponent<Scriptopen>().OpenPanel();
        //}
    }
    public void PrevBtn()
    {
        Debug.Log("PREVBUTTON");
        if (status_UI_script_auto == true)
        {
            Timer_set();
        }
        btnCount--;
        ScriptCount();
        //if (TextPanel != null)
        //{
        //    TextPanel.GetComponent<Scriptopen>().OpenPanel();
        //}
    }
    public void ScriptCount()
    {
        if (btnCount >= Max_num_script)
        {
            if (Fader != null && FadeOut == true)
            {
                Fader.GetComponent<Fader>().FadeOut(1);
                Invoke("InvokeNextScene", 1f);
            }
            else
                this.GetComponent<Dual_scene_loader>().LoadNextScene();
        }
        else if (btnCount < 0)
        {
            this.GetComponent<Dual_scene_loader>().LoadPrevScene();
        }
        else
        {
            Invoke("InvokeAct", 0.2f);
            //Debug.Log(btnCount);
            //Debug.Log(textList[0]);
            //Debug.Log("check_1");
        }
    }
    void InvokeAct()
    {
        text.text = textList[btnCount];
    }
    void InvokeNextScene()
    {
        this.GetComponent<Dual_scene_loader>().LoadNextScene();
    }

    void Timer_set()
    {
        script_time_now = Time_limit;
        Debug.Log("timer start" + script_time_now);
    }
     void Read_txt()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/10.Study_script/"+ Scene_number+".txt");
        textList.Clear();

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if(data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split('\n');
            for(int i = 0; i < data_values.Length; i++)
            {
                textList.Add(data_values[i]);                
                Max_num_script++;
                //Debug.Log(textList[i]);
            }
        }
        //첫번째 스크립트 텍스트 연결
        text.text = textList[0];
        //Debug.Log(Max_num_script);
    }

}
