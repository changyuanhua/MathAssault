using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_question_countdown_shower : MonoBehaviour, ui_value_shower
{
    private void Start()
    {
        countdown = controller.GetComponent<game_controller>();
    }

    private void LateUpdate()
    {
        ValueShow();
    }

    public void ValueShow()
    {
        canvas_timer_image.fillAmount = 1.0f -
              (Time.realtimeSinceStartup - countdown.question_asked_real_time) /
              countdown.question_countdown_second;
    }

    private game_controller countdown;

    public Transform controller;
    public Image canvas_timer_image;
}
