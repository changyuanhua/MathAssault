using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameover_score_shower : MonoBehaviour
{

    public void SetScore(int score)
    {
        canvas_score_text.text = score.ToString();
    }

    public Text canvas_score_text;
}
