using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narration_controller : MonoBehaviour
{
    public AudioClip[] AudioFiles;

    public float FirstNarrationDelay;
    public AudioSource Audio;
    AudioSource NarrationEnd;
    GameObject NextBtn;
    int BtnCount = 0;
    int PostCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Audio = GetComponent<AudioSource>();
        //Audio.clip = AudioFiles[0];
        //Audio.PlayDelayed(FirstNarrationDelay);
        //NarrationEnd = GameObject.Find("NarrationEnd").GetComponent<AudioSource>();
        NextBtn = GameObject.Find("NextEffect");
        // NarrationEnd.PlayDelayed(Audio.clip.length + FirstNarrationDelay);
        //Invoke("NextBtnEffect", Audio.clip.length + FirstNarrationDelay);
        Invoke("NextBtnEffect", 5f); //중간 평가용으로 수정
    }

    // Update is called once per frame
    void Update()
    {
        PlayNarrationWithCount();
    }
    void PlayNarrationWithCount()//When NextButton Pressed, Trigger Narration and Effect
    {
        BtnCount = gameObject.GetComponent<Script_controller>().btnCount;
        if (AudioFiles.Length > BtnCount)
        {
            if (PostCount != BtnCount)
            {
                EffectReset();
                Audio.clip = AudioFiles[BtnCount];
                Audio.PlayDelayed(1f);
                NarrationEnd.PlayDelayed(Audio.clip.length + 1f);
                Invoke("NextBtnEffect", Audio.clip.length + 1f);
            }
        }
        PostCount = BtnCount;
    }
    public void EffectReset()// Reset All Effect and Delay
    {
        CancelInvoke();
        NextBtn.GetComponent<Animation>().Stop();
        NextBtn.SetActive(false);
        //Audio.Stop();
        //NarrationEnd.Stop();
        Invoke("NextBtnEffect", 10f); //중간 평가용으로 수정
    }
    void NextBtnEffect()// UI Effect
    {
        NextBtn.SetActive(true);
        NextBtn.GetComponent<Animation>().Play("NextBtnEffect");
    }

}
