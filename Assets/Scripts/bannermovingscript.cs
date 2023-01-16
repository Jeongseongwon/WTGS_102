using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class bannermovingscript : MonoBehaviour
{
    public GameObject banner;
    public GameObject start;
    public GameObject end;
    private void Update()
    {
        
    }

    public void banner_up()
    {
        banner.GetComponent<RectTransform>().position = Vector3.MoveTowards(banner.GetComponent<RectTransform>().position,
       start.GetComponent<RectTransform>().position, 0.1f);
    }
    public void banner_down()
    {
        banner.GetComponent<RectTransform>().position = Vector3.MoveTowards(banner.GetComponent<RectTransform>().position,
       end.GetComponent<RectTransform>().position, 0.1f);
    }
}

