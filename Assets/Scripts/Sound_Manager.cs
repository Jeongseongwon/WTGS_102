using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;


    public static Sound_Manager Instance;
   
   void Awake()
   {
    if(Sound_Manager.Instance==null)
    {
        Sound_Manager.Instance=this;
    }
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
