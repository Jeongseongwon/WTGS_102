using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_box_singleton : MonoBehaviour
{
     private static Text_box_singleton instance = null;
     private Text scriptbix;
     private int num=0;
     public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;

    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static Text_box_singleton Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public void plus()
    {
        num++;
    }
    public void minus()
    {
        num--;
    }
    public void TextCall()
    {
        if(num==0)
        {
            Textbox1();

        }
        else if(num==1)
        {
            Textbox2();

        }
        else if(num==2)
        {
            Textbox3();
        }
    }

    public void Textbox1()
    {
         
         scriptbix=GameObject.Find("text_box").GetComponent<Text>();
         scriptbix.text="1번내용";
         play_Clip1();


    }

  public void Textbox2()
    {
         
         scriptbix=GameObject.Find("text_box").GetComponent<Text>();
         scriptbix.text="2번내용";
         play_Clip2();


    }

   public void Textbox3()
    {
         
         scriptbix=GameObject.Find("text_box").GetComponent<Text>();
         scriptbix.text="3번내용";


    }

   public void play_Clip1()
   {
    audioSource.PlayOneShot(audioClip1);
    Debug.Log("soundclip1");

   }
   public void play_Clip2()
   {
    audioSource.PlayOneShot(audioClip2);
   }
}

