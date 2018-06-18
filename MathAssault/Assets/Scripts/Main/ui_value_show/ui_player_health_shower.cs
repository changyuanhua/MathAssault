using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_player_health_shower : MonoBehaviour
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

    private player_controller health;

    public Transform player;
    public Text canvas_life_text;
    public Image canvas_life_regain_image;
}
