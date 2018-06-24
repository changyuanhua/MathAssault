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

    public void Ready()
    {
        Image image = Instantiate(available_image);
        image.rectTransform.SetParent(transform, false);
        Destroy(image.gameObject, available_show_time);

        Text text = Instantiate(available_text);
        text.rectTransform.SetParent(transform, false);
    }

    private skill_multishot_weapon_controller skill;

    public Transform player;
    public Image canvas_ammunition_reload_image;
    public Image available_image;
    public Text available_text;
    public float available_show_time;
}
