using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject lightshipOrbitCamera;
    [SerializeField] private CameraFocusedState cameraFocusedState;

    public void FocusOn(Transform target)
    {
        if (lightshipOrbitCamera.activeInHierarchy) 
            lightshipOrbitCamera.SetActive(false);

        if (!cameraFocusedState.gameObject.activeInHierarchy)
            cameraFocusedState.gameObject.SetActive(true);

        cameraFocusedState.SetTarget(target);
    }

    public void BreakFocus()
    {
        if (!lightshipOrbitCamera.activeInHierarchy)
            lightshipOrbitCamera.SetActive(true);

        if (cameraFocusedState.gameObject.activeInHierarchy)
            cameraFocusedState.gameObject.SetActive(false);
    }
}
