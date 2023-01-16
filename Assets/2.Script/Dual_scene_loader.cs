using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dual_scene_loader : MonoBehaviour
{

    int sceneNum;
    // Start is called before the first frame update
    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadNextScene()
    {
        if (sceneNum == SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadSceneAsync(1);
        else
            SceneManager.LoadSceneAsync(sceneNum + 1);
    }
    public void LoadPrevScene()
    {

        SceneManager.LoadSceneAsync(sceneNum - 1);
    }

}
