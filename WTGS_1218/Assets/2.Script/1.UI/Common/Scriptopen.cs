using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scriptopen : MonoBehaviour
{
    public float delayTime;
    Animator animator;

    private bool status_script_hide = false;
    public void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.SetFloat("Delay", 0f);
    }
    public void OpenPanel()
    {//접엇다가 다시 펴주기

        if (Manager_scene.instance != null)
        {
            status_script_hide = Manager_scene.instance.Status_Check_script_hide();
        }

        if (status_script_hide == false)
        {
            animator.enabled = true;

            if (animator != null)
            {
                bool isOpen = animator.GetBool("Open");
                animator.SetBool("Open", true);
                Invoke("invokeAct", 0.2f);
            }
            Debug.Log("open panel");
        }


    }
    void invokeAct()
    {
        animator.SetBool("Open", false);
    }
    private void Update()
    {
        if (delayTime > -1)
        {
            delayTime -= Time.deltaTime;
        }
        else
        {
            animator.SetFloat("Delay", delayTime);
        }
    }
}
