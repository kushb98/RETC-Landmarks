using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionInteractable : InteractableObject
{
    [Header("References")]
    [SerializeField] private MeshRenderer objectMaterial;

    [Header("Settings")]
    [SerializeField] private int rewardEXP = 500;
    [SerializeField] private Color readyColor = Color.green;
    [SerializeField] private Color consumedColor = Color.gray;
    [SerializeField] private Color outOfRangeColor = Color.black;

    protected override void Start()
    {
        base.Start();

        objectMaterial.material.color = outOfRangeColor;
    }
    protected override void MakeReady()
    {
        base.MakeReady();

        objectMaterial.material.color = readyColor;
    }

    protected override void Consume()
    {
        base.Consume();

        objectMaterial.material.color = consumedColor;

        QuestionSystem.Instance.AskRandomQuestion();
    }

    protected override void OnOutOfRange()
    {
        base.OnOutOfRange();

        objectMaterial.material.color = outOfRangeColor;
    }

    protected override void OnInRange()
    {
        base.OnInRange();
        if (_ready)
            objectMaterial.material.color = readyColor;
        else
            objectMaterial.material.color = consumedColor;
    }
}
