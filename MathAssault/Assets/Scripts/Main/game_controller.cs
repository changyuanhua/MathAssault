using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class game_controller : MonoBehaviour
{
    private void Start()
    {
        is_answering_question = false;
        askquestion_show = is_answering_question;
        shooting_canvas.enabled = true;
        question_canvas.enabled = false;
        gameover_canvas.enabled = false;

        current_score = 0;
        if (!player)
        {
            Debug.LogError("Player not found");
        }

        score_shower = gameover_canvas.GetComponent<gameover_score_shower>();
        spawner = GetComponent<object_spawn_controller>();
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
        SecretKey();
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

    public void PlayerAnswer(bool reply, int answer = 0)
    {
        if (is_answering_question)
        {
            if (reply)
            {
                if (question.answer == answer)
                {
                    int get_score = (int)QuestionTimeRemain() * score_ratio;
                    GetScore(get_score);
                    Debug.Log("question: correct (" +
                              get_score.ToString() + ")");
                    target.GetComponent<tank_controller>().Destroy();
                    spawner.Spawn();
                }
                else
                {
                    Debug.Log("question: incorrect");
                    wrong_sound.Play();
                }
            }
            else
            {
                Debug.Log("question: failed to reply");
                wrong_sound.Play();
            }
            is_answering_question = false;
            askquestion_show = is_answering_question;
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
            askquestion_show = is_answering_question;
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

    public void GetScore(int score)
    {
        current_score += score;

        Text clone = Instantiate(score_add_shower);
        clone.rectTransform.SetParent(score_transform,
                                      false);
        clone.text = score.ToString();
        Destroy(clone.gameObject, 1.5f);

        correct_sound.Play();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        askquestion_show = true;
        shooting_canvas.enabled = false;
        question_canvas.enabled = false;
        gameover_canvas.enabled = true;
        score_shower.SetScore(current_score);
        gameover_sound.Play();
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

    public void SecretKey()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Transform clone = Instantiate(powerups,
                                          transform.position + Vector3.up,
                                          Quaternion.identity);
            clone.GetComponent<random_powerup_controller>()
            .game_controller_object = transform;
        }
    }

    private object_spawn_controller spawner;

    private bool _is_answering_question;
    public bool is_answering_question
    {
        get { return _is_answering_question; }
        protected set { _is_answering_question = value; }
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

    public int current_score;

    public Canvas gameover_canvas;
    private gameover_score_shower score_shower;

    public static bool askquestion_show;
    public Canvas shooting_canvas;
    public Canvas question_canvas;
    public Transform score_transform;
    public Text math_operator;
    public Text first_argument;
    public Text second_argument;
    public List<Button> answer_buttons;
    public Text score_add_shower;

    public AudioSource correct_sound;
    public AudioSource wrong_sound;
    public AudioSource gameover_sound;

    public Transform powerups;
}
