using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_score_shower : MonoBehaviour, ui_value_shower
{
    private void Start()
    {
        controller = score.GetComponent<game_controller>();
    }

    private void LateUpdate()
    {
        ValueShow();
    }

    public void ValueShow()
    {
        canvas_score_text.text = controller.current_score.ToString();
    }

    private game_controller controller;

    public Transform score;
    public Text canvas_score_text;
}
