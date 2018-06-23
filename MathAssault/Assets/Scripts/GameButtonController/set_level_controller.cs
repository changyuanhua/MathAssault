using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class set_level_controller : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        main_menu.enabled = false;
        level_menu.enabled = true;
    }

    public Canvas main_menu;
    public Canvas level_menu;
}
