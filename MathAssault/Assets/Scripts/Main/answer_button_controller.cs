using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class answer_button_controller : MonoBehaviour, IPointerClickHandler {

    public void OnPointerClick(PointerEventData eventData)
    {
        int answer = int.Parse(GetComponentInChildren<Text>().text);
        controller.PlayerAnswer(true, answer);
    }

    public game_controller controller;
}
