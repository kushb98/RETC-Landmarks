using System;

using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Question System/Create New Question")]
public class Question : ScriptableObject
{
    [SerializeField] private string question;
    [SerializeField] private string[] answers;
    [SerializeField] private AnswerEnum correctAnswer;
    [SerializeField] private int rewardEXP = 500;

    public enum AnswerEnum
    {
        A, B, C, D, E, F, G, H
    }

    public string QuestionString
    {
        get { return question; }
    }

    public string[] AnswerStrings
    {
        get { return answers; }
    }

    public AnswerEnum CorrectAnswer
    {
        get { return correctAnswer; }
    }

    public int RewardEXP
    {
        get { return rewardEXP; }
    }
}
