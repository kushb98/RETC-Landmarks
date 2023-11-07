using Niantic.Lightship.Maps.Core.Coordinates;
using Niantic.Lightship.Maps.MapLayers.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class CoordinateSpawner : MonoBehaviour
{
    [SerializeField] private LayerGameObjectPlacement _objectSpawner; // A "LayerGameObjectPlacement" is a MapLayer that places a particular obejct

    void Start()
    {
        SpawnObejct();
    }

    private void SpawnObejct()
    {
        LatLng location = new LatLng(47.620670, -122.348363);
        var rotation = new Quaternion(0, 0, 0, 0);

        _objectSpawner.PlaceInstance(location, rotation);
    }
}
