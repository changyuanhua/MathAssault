using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class view_button_controller : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        math_assault_controller.view = view;
        Debug.Log(math_assault_controller.view);
        main_menu.enabled = true;
        view_menu.enabled = false;
    }

    public viewer view;
    public Canvas main_menu;
    public Canvas view_menu;
}
