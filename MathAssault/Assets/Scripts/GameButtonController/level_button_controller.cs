using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class level_button_controller : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        math_assault_controller.level = level;
        Debug.Log(math_assault_controller.level);
        main_menu.enabled = true;
        level_menu.enabled = false;
    }

    public difficulty level;
    public Canvas main_menu;
    public Canvas level_menu;
}
