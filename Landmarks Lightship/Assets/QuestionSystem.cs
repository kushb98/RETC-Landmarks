using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using static Question;

public class QuestionSystem : MonoBehaviour
{
    public static QuestionSystem Instance;
    public AudioManager audioManager;

    [SerializeField] private Question[] potentialQuestions;
    private List<Question> potentialQuestionsList = new List<Question>();

    [Header("UI Elements")]
    [SerializeField] AnswerOption[] answerOptions;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI attemptsLeftText;

    // Stats abt the current question
    private Question _currentQuestion;
    private AnswerEnum correctAnswer;
    private int attemptsLeft = 2; // Number of attempts allowed
    

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        if (Instance == null)
            Instance = this;    

        potentialQuestionsList.AddRange(potentialQuestions);

        gameObject.SetActive(false);
    }

    public void AskRandomQuestion()
    {

        gameObject.SetActive(true);

        Question question = potentialQuestionsList[Random.Range(0, potentialQuestionsList.Count)];

        SetQuestion(question);
    }

    private void SetQuestion(Question question)
    {
        ResetAttempts();

        _currentQuestion = question;

        questionText.text = question.QuestionString;
        correctAnswer = question.CorrectAnswer;

        // Set the answer options
        for (int i = 0; i < question.AnswerStrings.Length; i++)
        {
            Debug.Log("Setting answer " + i + " to " + question.AnswerStrings[i]);
            answerOptions[i].SetQuestion(question.AnswerStrings[i]);
        }

        for (int i = question.AnswerStrings.Length; i < answerOptions.Length; i++)
        {
            answerOptions[i].Disable();
        }
    }

    public void SelectAnswer(int answerEnum)
    {
        int answerIndex = (int)answerEnum;

        if (answerEnum == (int)correctAnswer)
        {
            OnCorrectAnswerChosen();
        }
        else
        {
            audioManager.Play(audioManager.playerIncorrect);
            Debug.Log("Incorrect!");
            attemptsLeft--;
            attemptsLeftText.text = "Attempts Left: " + attemptsLeft.ToString();

            if (attemptsLeft <= 0)
            {
                Debug.Log("Out of attempts!");
            }
        }
    }

    private void OnCorrectAnswerChosen()
    {
        audioManager.Play(audioManager.playerCorrect);

        RankManager.Singleton.IncreaseEXP(_currentQuestion.RewardEXP);

        Debug.Log("Correct!");

        potentialQuestionsList.Remove(_currentQuestion);

        gameObject.SetActive(false);
    }

    private void ResetAttempts()
    {
        attemptsLeft = 2;
        attemptsLeftText.text = "Attempts Left: " + attemptsLeft.ToString();
    }
}
