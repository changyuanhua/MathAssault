using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class change_scene_controller : MonoBehaviour, IPointerClickHandler
{
    public string sceneName;
    public void OnPointerClick(PointerEventData eventData)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }
}
