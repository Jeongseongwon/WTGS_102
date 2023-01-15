using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_button : MonoBehaviour
{

    //0 : 스크립트 고정 버튼 
    //1 : 스크립트 고정 버튼 "누름" 
    //2 : 스크립트 자동 재생 버튼
    //3 : 스크립트 자동 재생 버튼 "누름"
    //4 : prev 버튼
    //5 : prev 버튼 "호버"
    //6 : next 버튼
    //7 : next 버튼 "호버"
    

    public Sprite [] Sprites_button;
    
    [Multiline(3)]
    public Dictionary<string, string> textList_1 = new Dictionary<string, string>();

    //Start is called before the first frame update
    //void Start()
    //{

    //}

    //Update is called once per frame
    //void Update()
    //{

    //}

    public Sprite Script_fix_image()
    {
        return Sprites_button[0];
    }

    public Sprite Script_fix_image_press()
    {
        return Sprites_button[1];
    }

    public Sprite Script_auto_image()
    {
        return Sprites_button[2];
    }

    public Sprite Script_auto_image_press()
    {
        return Sprites_button[3];
    }
    public Sprite Button_prev_image()
    {
        return Sprites_button[4];
    }

    public Sprite Button_prev_image_press()
    {
        return Sprites_button[5];
    }

    public Sprite Button_next_image()
    {
        return Sprites_button[6];
    }

    public Sprite Button_next_image_press()
    {
        return Sprites_button[7];
    }
}
