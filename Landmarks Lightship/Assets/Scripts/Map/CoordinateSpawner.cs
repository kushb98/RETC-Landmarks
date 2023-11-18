using Niantic.Lightship.Maps.Core.Coordinates;
using Niantic.Lightship.Maps.MapLayers.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class CoordinateSpawner : MonoBehaviour
{

    [SerializeField] private LayerGameObjectPlacement _objectSpawner; // A "LayerGameObjectPlacement" is a MapLayer that places a particular obejct

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnObejct(47.620513f, -122.349303f + i * 0.001f);
        }
    }

    private void SpawnObejct(float northSouth, float eastWest)
    {
        LatLng location = new LatLng(northSouth, eastWest);
        var rotation = new Quaternion(0, 0, 0, 0);  // How can we make this rotation always face the street, or the player if not the street

        _objectSpawner.PlaceInstance(location, rotation);
    }


}
