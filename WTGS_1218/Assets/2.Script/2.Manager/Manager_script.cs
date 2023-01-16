using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_script : MonoBehaviour
{
    public static Manager_script instance = null;   //인스턴스 이름은 스크립트 이름과 동일하게

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            if (instance != this) 
                Destroy(this.gameObject); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
