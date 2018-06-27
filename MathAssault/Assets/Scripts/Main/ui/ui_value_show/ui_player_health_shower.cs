using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_player_health_shower : MonoBehaviour, ui_value_shower
{
    private void Start()
    {
        health = player.GetComponent<player_controller>();
    }

    private void LateUpdate()
    {
        ValueShow();
    }

    public void ValueShow()
    {
        canvas_life_text.text = health.current_life.ToString();
        canvas_life_regain_image.fillAmount
            = 1.0f - (health.life_regain_time / health.life_regain_delta);
    }

    public void AddLife(int life)
    {
        Text text = Instantiate(adder_text);
        text.text = life.ToString();
        text.rectTransform.SetParent(transform, false);
    }

    private player_controller health;

    public Transform player;
    public Text canvas_life_text;
    public Image canvas_life_regain_image;
    public Text adder_text;
}
