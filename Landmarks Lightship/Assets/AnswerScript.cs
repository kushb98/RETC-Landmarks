using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AnswerScript.cs
public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuestionSystem questionSystem;

    public void OptionSelected(int optionIndex)
    {
        // Pass the selected option index to the QuestionSystem
        questionSystem.OptionSelected(optionIndex);
    }
}
