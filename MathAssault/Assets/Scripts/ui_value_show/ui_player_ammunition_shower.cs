using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_player_ammunition_shower : MonoBehaviour, ui_value_shower
{
    private void Start()
    {
        weapon = player.GetComponent<player_weapon_controller>();
    }

    private void LateUpdate()
    {
        ValueShow();
    }

    public void ValueShow()
    {
        canvas_ammunition_text.text = weapon.current_ammunition.ToString();
        canvas_ammunition_reload_image.fillAmount
            = 1.0f - (weapon.shot_reload_time / weapon.reload_delta);
    }

    private player_weapon_controller weapon;

    public Transform player;
    public Text canvas_ammunition_text;
    public Image canvas_ammunition_reload_image;
}
