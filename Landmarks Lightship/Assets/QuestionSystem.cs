using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class QuestionSystem : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public List<QuestionsandAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    private int attemptsLeft = 2; // Number of attempts allowed

    private void Start()
      {
          generateQuestion();
      }

    public void OptionSelected(int selectedOptionIndex)
      {
          if (options[selectedOptionIndex].GetComponent<AnswerScript>().isCorrect)
          {
              // Code for correct answer
          }
          else
          {
              attemptsLeft--;

              // Disable the selected incorrect option
              options[selectedOptionIndex].SetActive(false);

              if (attemptsLeft <= 0)
              {
                  // Maximum attempts reached for this question
                  Debug.Log("Maximum attempts reached for this question.");
                  QnA.RemoveAt(currentQuestion);
                  attemptsLeft = 2; // Reset attempts for the next question
                  generateQuestion();
              }
              else
              {
                  // Show remaining options for the second attempt
                  ShowRemainingOptions();
              }
          }
      }

    void ShowRemainingOptions()
      {
          bool correctOptionActive = false;

          // Disable incorrect options, keeping the correct one intact
          for (int i = 0; i < options.Length; i++)
          {
              if (!options[i].GetComponent<AnswerScript>().isCorrect && options[i].activeSelf)
              {
                  options[i].SetActive(false);
              }
              else if (options[i].GetComponent<AnswerScript>().isCorrect && options[i].activeSelf)
              {
                  correctOptionActive = true;
              }
          }

          // Ensure the correct option remains active if it was active before
          if (!correctOptionActive)
          {
              for (int i = 0; i < options.Length; i++)
              {
                  if (options[i].GetComponent<AnswerScript>().isCorrect)
                  {
                      options[i].SetActive(true);
                      break;
                  }
              }
          }
      }




    void RemoveIncorrectOption()
      {
          for (int i = 0; i < options.Length; i++)
          {
              if (!options[i].GetComponent<AnswerScript>().isCorrect)
              {
                  options[i].SetActive(false); // Disable the GameObject of the incorrect option
              }
          }
      }

    void SetAnswers()
      {
          for (int i = 0; i < options.Length; i++)
          {
              options[i].GetComponent<AnswerScript>().isCorrect = false;
              TextMeshProUGUI textComponent = options[i].GetComponentInChildren<TextMeshProUGUI>();

              if (textComponent != null)
              {
                  textComponent.text = QnA[currentQuestion].Answers[i];
              }
              else
              {
                  Debug.LogError("Text component not found in option " + i);
              }

              if (QnA[currentQuestion].CorrectAnswer == i + 1)
              {
                  options[i].GetComponent<AnswerScript>().isCorrect = true;
              }
          }
      }

    void generateQuestion()
      {
          if (QnA.Count > 0)
          {
              currentQuestion = Random.Range(0, QnA.Count);

              questionText.text = QnA[currentQuestion].Questions;
              SetAnswers();
          }
          else
          {
              Debug.LogError("QnA list is empty! Ensure it has questions and answers.");
          }
      }
}
