using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using static Question;

public class QuestionSystem : MonoBehaviour
{
    [SerializeField] private Question[] potentialQuestions;

    [Header("UI Elements")]
    [SerializeField] AnswerOption[] answerOptions;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI attemptsLeftText;

    // Stats abt the current question
    private AnswerEnum correctAnswer;
    private int attemptsLeft = 2; // Number of attempts allowed

    private void Start()
    {
        // Set the question to a random question to test
        SetQuestion(potentialQuestions[Random.Range(0, potentialQuestions.Length)]);
    }

    private void SetQuestion(Question question)
    {
        questionText.text = question.QuestionString;
        correctAnswer = question.CorrectAnswer;

        // Set the answer options
        for (int i = 0; i < answerOptions.Length; i++)
        {
            answerOptions[i].SetQuestion(question.AnswerStrings[i]);
        }

        for (int i = answerOptions.Length; i < question.AnswerStrings.Length; i++)
        {
            answerOptions[i].Disable();
        }
    }

    public void SelectAnswer(int answerEnum)
    {
        int answerIndex = (int)answerEnum;

        if (answerEnum == (int)correctAnswer)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Incorrect!");
            attemptsLeft--;
            attemptsLeftText.text = attemptsLeft.ToString();

            if (attemptsLeft <= 0)
            {
                Debug.Log("Out of attempts!");
            }
        }
    }
}
