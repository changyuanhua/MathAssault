using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_controller : MonoBehaviour
{
    private void Start()
    {
        is_answering_question = false;
        shooting_canvas.enabled = true;
        question_canvas.enabled = false;

        score = 0;
        if (!player)
        {
            Debug.LogError("Player not found");
        }
    }

    public void PlayerAnswer(bool reply, int answer = 0)
    {
        if (is_answering_question)
        {
            if (reply)
            {
                if (question.answer == answer)
                {
                    int get_score = (int)QuestionTimeRemain() * score_ratio;
                    Debug.Log("question: correct (" +
                               get_score.ToString() + ")");
                    target.GetComponent<tank_controller>().Destroy();
                    score += get_score;
                }
                else
                {
                    Debug.Log("question: incorrect");
                }
            }
            else
            {
                Debug.Log("question: failed to reply");
            }
            is_answering_question = false;
            SetCanvas();

            Time.timeScale = 1.0f;
        }
    }

    public void AskQuestion(Transform attacked_target)
    {
        Debug.Log("Is asking question");
        if (!is_answering_question)
        {
            is_answering_question = true;
            question = new math_questions(math_assault_controller.level);
            SetCanvas();
            SetQuestion();
            SetAnswer();
            target = attacked_target;
            Time.timeScale = 0.0f;
            question_asked_real_time = Time.realtimeSinceStartup;
            Debug.Log(question.first_value.ToString() + " " +
                      question.math_operator.ToString() + " " +
                      question.second_value + " = " +
                      question.answer);
        }
    }

    private void Update()
    {
        if (is_answering_question)
        {
            if (QuestionCountDownOver())
            {
                PlayerAnswer(false);
            }
        }
    }

    public void SetCanvas()
    {
        shooting_canvas.enabled = !is_answering_question;
        question_canvas.enabled = is_answering_question;
    }

    public void SetQuestion()
    {
        math_operator.text = question.OperatorToString();
        first_argument.text = question.first_value.ToString();
        second_argument.text = question.second_value.ToString();
    }

    public void SetAnswer()
    {
        int choose = Random.Range(0, answer_buttons.Count);
        for (int iter = 0; iter < answer_buttons.Count; ++iter)
        {
            if (iter == choose)
            {
                answer_buttons[iter].GetComponentInChildren<Text>().text
                    = question.answer.ToString();
            }
            else
            {
                int fake_offset = Random.Range(-question.question_range.max,
                                               question.question_range.max);
                fake_offset = ((fake_offset == 0) ? 1 : fake_offset);

                answer_buttons[iter].GetComponentInChildren<Text>().text
                    = (question.answer + fake_offset).ToString();
            }
        }
    }

    public bool QuestionCountDownOver()
    {
        return (QuestionTimeRemain() <= 0.0f);
    }

    public float QuestionTimeRemain()
    {
        return question_asked_real_time + question_countdown_second -
               Time.realtimeSinceStartup;
    }

    private bool _is_answering_question;
    public bool is_answering_question
    {
        get { return _is_answering_question; }
        protected set { _is_answering_question = value; }
    }

    public int test
    {
        get;
        set;
    }

    private math_questions question;
    public float question_countdown_second;
    private float _question_asked_real_time;
    public float question_asked_real_time
    {
        get { return _question_asked_real_time; }
        protected set { _question_asked_real_time = value; }
    }
    public int score_ratio = 1;

    public Transform player;
    private Transform target;

    private int _score;
    public int score
    {
        get { return _score; }
        protected set { _score = value; }
    }

    public Canvas shooting_canvas;
    public Canvas question_canvas;
    public Text math_operator;
    public Text first_argument;
    public Text second_argument;
    public List<Button> answer_buttons;
}
