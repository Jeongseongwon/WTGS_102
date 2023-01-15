using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//사용하기 위해서 툴팁을 보여줄 오브젝트에 Object_mouseover~ 함수 넣고 텍스트 입력해줄 것
//Tooltip 프리팹 캔버스에 집어넣으면 화면상에 나타남
public class Tooltip : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Text_tooltip;   //자식 오브젝트 text 넣음
    public Image Text_image;
   
    //여기다가 그 기능도 추가하기
    // Update is called once per frame
    void Update()
    {
        Update_MousePosition();
    }
    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition + (new Vector3(0,20)*2f);
        this.gameObject.GetComponent<RectTransform>().position = mousePos;       
    }

    //오브젝트에서 함수 호출
    public void Change_text(string text)
    {
        Text_tooltip.GetComponent<Text>().text= text;
        RectTransform rect_1 = (RectTransform)Text_image.transform;
        rect_1.sizeDelta = new Vector2(text.Length * 30, 50);

        RectTransform rect_2 = (RectTransform)Text_tooltip.transform;
        rect_2.sizeDelta = new Vector2(text.Length * 30, 50);
    }
    //스트링 사이즈에 따라서 배경 이미지 width값 조절해주기
}
