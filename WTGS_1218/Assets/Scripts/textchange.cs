using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;


public class textchange : MonoBehaviour
{
    float timer;
    int waitingTime;
    private int frame=0;
    public Text textsizechange;
    public string sizemin;
    public string sizemax;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 1;
     

    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
    }
    // Update is called once per frame
    void Update()
    {
        if(frame<=3)
        {
           
            textsizechange.GetComponent<Text>().text = sizemin;
            timer += Time.deltaTime;

            if (timer > waitingTime)
            {
                //Action
                timer = 0;
                frame++;
            }
        }
        else if(3<=frame && frame<=6)
        {
            textsizechange.GetComponent<Text>().text = sizemax;
          
            timer += Time.deltaTime;

            if (timer > waitingTime)
            {
                //Action
                frame++;
                timer = 0;
            }


        }
        else
        {
            frame = 0;
        }
        
    }
}
