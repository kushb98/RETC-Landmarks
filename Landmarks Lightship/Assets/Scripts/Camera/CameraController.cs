using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The CameraController class is responsible for managing the active / inactive state of lightships's orbit camera, and a second focus camera.
/// It provides methods to focus on a specific target by enabling the focus camera and disabling the lightship camera, and vice versa.
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject lightshipOrbitCamera;
    [SerializeField] private CameraFocusedState cameraFocusedState;

    /// <summary>
    /// Focuses on a specific target by disabling the lightshipOrbitCamera and enabling the cameraFocusedState (which holds the focus camera).
    /// </summary>
    /// <param name="target">The Transform object to focus on.</param>
    public void FocusOn(Transform target)
    {
        if (lightshipOrbitCamera.activeInHierarchy)
            lightshipOrbitCamera.SetActive(false);

        if (!cameraFocusedState.gameObject.activeInHierarchy)
            cameraFocusedState.gameObject.SetActive(true);

        cameraFocusedState.SetTarget(target);
    }

    /// <summary>
    /// Breaks the focus by enabling the lightshipOrbitCamera and disabling the cameraFocusedState.
    /// </summary>
    public void BreakFocus()
    {
        if (!lightshipOrbitCamera.activeInHierarchy)
            lightshipOrbitCamera.SetActive(true);

        if (cameraFocusedState.gameObject.activeInHierarchy)
            cameraFocusedState.gameObject.SetActive(false);
    }
}
