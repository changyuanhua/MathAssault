using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class set_view_controller : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        main_menu.enabled = false;
        view_menu.enabled = true;
    }

    public Canvas main_menu;
    public Canvas view_menu;
}