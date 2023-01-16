using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_button_highlight : MonoBehaviour, IPointerClickHandler

{

    private GameObject SceneController;
    bool pingPong = false;
    // Start is called before the first frame update
    void Start()
    {
        SceneController = GameObject.FindGameObjectWithTag("Scene_controller");
    }

    // Update is called once per frame
    void Update()
    {
        Color c = gameObject.GetComponent<Image>().color;
        if (pingPong)
        {
            c.a += Time.deltaTime * 0.7f;

            if (c.a >= 0.6)
                pingPong = false;
        }
        else
        {
            c.a -= Time.deltaTime * 0.7f;
            if (c.a <= 0)
                pingPong = true;
        }

        c.a = Mathf.Clamp01(c.a);
        GetComponent<Image>().color = c;

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        BtnAct();
    }

    public void BtnAct()
    {
        SceneController.GetComponent<Script_controller>().NextBtn();
        Debug.Log("next button click");
    }
}
