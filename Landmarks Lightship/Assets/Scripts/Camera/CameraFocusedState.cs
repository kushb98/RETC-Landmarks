using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusedState : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera mainCamera;

    [Header("Settings")]
    [SerializeField] private float roatateRate = 2f;
    [SerializeField] private float roatateDistance = 3f;
    [SerializeField] private float lookUpAmmount = 1f;
    [SerializeField] private float cameraHeight = 3;

    private float _angle = 0f;
    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void LateUpdate()
    {
        _angle += roatateRate * Time.deltaTime;

        Vector3 rotatedPosition = Quaternion.AngleAxis(_angle, Vector3.up) * Vector3.right;
        rotatedPosition = rotatedPosition.normalized * roatateDistance;

        mainCamera.transform.position = _target.position + rotatedPosition + Vector3.up * cameraHeight;
        mainCamera.transform.LookAt(_target.position + (Vector3.up * lookUpAmmount));
    }
}
