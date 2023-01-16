using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_audio : MonoBehaviour
{
    public static Manager_audio instance = null;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void Get_hover()
    {
        this.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
        //Debug.Log("hover");
    }

    public void Get_click()
    {
        this.transform.GetChild(1).gameObject.GetComponent<AudioSource>().Play();
        //Debug.Log("click");
    }
    
}
