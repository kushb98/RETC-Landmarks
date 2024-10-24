using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// AnswerScript.cs
public class AnswerOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;

    public void SetQuestion(string answerString)
    {
        answerText.text = answerString;

        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
