using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_button_2_1 : MonoBehaviour, IPointerClickHandler
{
    private string Object_name;
    private GameObject SceneController;
    public void OnPointerClick(PointerEventData eventData)
    {
        //각 기능 별로 추가하기

        Debug.Log(this.gameObject.name);
        if (Object_name == "Button_+")
        {
            //+의 경우 애니메이션, 신 컨트롤러에서 값을 관리하는게 맞을 것 같음, 값 올리기
            //transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
            SceneController.GetComponent<Scene_2_1_controller>().Set_add_pitch();
            SceneController.GetComponent<Scene_2_1_controller>().Rotate_blade_up();
        }
        else if (Object_name == "Button_-")
        {
            //-의 경우 애니메이션, 값 내리기
            SceneController.GetComponent<Scene_2_1_controller>().Set_reduce_pitch();
            SceneController.GetComponent<Scene_2_1_controller>().Rotate_blade_down();
        }
        else if (Object_name == "Button_Stop")
        {
            //비상정지의 경우 브레이크 등 점멸, 애니메이션 정지, 바람 효과 유지, 
            SceneController.GetComponent<Scene_2_1_controller>().Stop();
        }
        else if (Object_name == "Button_Start")
        {
            //START의 경우 풍력발전기 애니메이션, 바람 효과, 다른 그래프들 데이터 화면 투사
        }
        //else if (Object_name == "Button_+")
        //{

        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        Object_name = this.gameObject.name;
        
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
    }
}
