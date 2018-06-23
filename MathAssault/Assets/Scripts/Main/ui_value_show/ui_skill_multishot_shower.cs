using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_skill_multishot_shower : MonoBehaviour, ui_value_shower
{
    private void Start()
    {
        skill = player.GetComponent<skill_multishot_weapon_controller>();
    }

    private void LateUpdate()
    {
        ValueShow();
    }

    public void ValueShow()
    {
        canvas_ammunition_reload_image.fillAmount
            = 1.0f - (skill.shot_reload_time / skill.reload_delta);
    }

    private skill_multishot_weapon_controller skill;

    public Transform player;
    public Image canvas_ammunition_reload_image;
}
