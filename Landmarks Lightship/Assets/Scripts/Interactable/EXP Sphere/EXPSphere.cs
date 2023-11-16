using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPSphere : InteractableObject
{
    [Header("References")]
    [SerializeField] private MeshRenderer objectMaterial;

    [Header("Settings")]
    [SerializeField] private int rewardEXP = 500;
    [SerializeField] private Color readyColor = Color.green;
    [SerializeField] private Color consumedColor = Color.gray;

    protected override void Start()
    {
        base.Start();

        objectMaterial.material.color = readyColor;
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

        RankManager.Singleton.IncreaseEXP(rewardEXP);
    }
}
