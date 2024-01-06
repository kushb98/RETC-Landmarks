using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmark : InteractableObject
{
    [Header("Settings")]
    [SerializeField] private bool facePlayer;

    private Transform _billboardingTarget;

    protected override void Start()
    {
        base.Start();

        _billboardingTarget = PlayerController.Instance.transform;
    }

    private void Update()
    {
        if (facePlayer)
        {
            FacePlayer();
        }
    }

    private void FacePlayer()
    {
        Vector3 vectorToTarget = transform.position - _billboardingTarget.position;

        vectorToTarget.y = 0;

        transform.rotation = Quaternion.LookRotation(vectorToTarget);
    }
}
