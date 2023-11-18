using Niantic.Lightship.Maps.MapLayers.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Niantic.Lightship.Maps.MapLayers;
using Niantic.Lightship.Maps.Core.Coordinates;
using Niantic.Lightship.Maps;

/* Basic placement test from the tutorial at 
 * https://lightship.dev/docs/beta/maps/unity/how-to/place_objects_on_map/
 * By Martin Allsbrook martin.allsbrook@colorado.edu
 */

public class PlacementTester : MonoBehaviour
{
    [SerializeField] private LayerGameObjectPlacement _objectSpawner; // A "LayerGameObjectPlacement" is a MapLayer that places a particular obejct

    [SerializeField] private Camera _mapCamera;

    [SerializeField] private LightshipMapView _lightshipMapView;

    // Basic Update method to get inputs
    private void Update()
    {
        var touchPosition = Vector3.zero;
        bool touchDetected = false;

        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                touchPosition = Input.touches[0].position;
                touchDetected = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
            touchDetected = true;
        }

        if (touchDetected)
        {
            TestObjectPlacement(touchPosition);
        }
    }

    private void TestObjectPlacement(Vector3 touchPosition)
    {
        var location = ScreenPointToLatLong(touchPosition);
        var cameraForward = _mapCamera.transform.forward;
        var forward = new Vector3(cameraForward.x, 0f, cameraForward.z).normalized;
        var rotation = Quaternion.LookRotation(forward);

        _objectSpawner.PlaceInstance(location, rotation);
    }

    // Method coppied from MapGameMapInterations.cs
    private LatLng ScreenPointToLatLong(Vector3 screenPosition)
    {
        var clickRay = _mapCamera.ScreenPointToRay(screenPosition);
        var pointOnMap = clickRay.origin + clickRay.direction * (-clickRay.origin.y / clickRay.direction.y);
        return _lightshipMapView.SceneToLatLng(pointOnMap);
    }
}
