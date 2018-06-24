using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_shaker : MonoBehaviour
{
    private void Start()
    {
        current_shake_amplitude = 0.0f;
        reach_max_amplitude = false;
    }
    public void LateUpdate()
    {
        if (is_shaking)
        {
            if (reach_max_amplitude && current_shake_amplitude < 0.0f)
            {
                is_shaking = false;
                reach_max_amplitude = false;
                current_shake_amplitude = 0.0f;
            }
            else if (!reach_max_amplitude &&
                     current_shake_amplitude > shake_amplitude)
            {
                reach_max_amplitude = true;
                current_shake_amplitude = shake_amplitude;
            }
            else
            {
                current_shake_amplitude += FrameShakeAmplitude();
            }

            foreach (RectTransform ui in ui_list)
            {
                ui.anchoredPosition3D = new Vector3(ui.anchoredPosition3D.x,
                                                    ui.anchoredPosition3D.y,
                                                    current_shake_amplitude);
            }
        }
    }

    public void Shake()
    {
        is_shaking = true;
        reach_max_amplitude = false;
    }

    private float FrameShakeAmplitude()
    {
        return Time.deltaTime * shake_speed * (reach_max_amplitude ? -1 : 1);
    }

    public List<RectTransform> ui_list;
    private bool is_shaking;
    public float shake_amplitude = 1.0f;
    public float shake_speed = 1.0f;
    private float current_shake_amplitude = 0.0f;
    private bool reach_max_amplitude = false;
}
