using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Scene_change : MonoBehaviour, IPointerClickHandler

{
    public string SceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            LoadScene();
        }
    }
    private void LoadScene()
    {
        SceneManager.LoadSceneAsync(SceneName);
    }
}
