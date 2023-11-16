using Niantic.Lightship.Maps.Core.Coordinates;
using Niantic.Lightship.Maps.MapLayers.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;



public class CoordinateSpawner : MonoBehaviour
{
    [Serializable]
    public class SpawnPoint
    {
        [SerializeField] private float latNorth = 47.620513f;
        [SerializeField] private float lngEast = -122.349303f;
        [SerializeField] private Quaternion rotation = new Quaternion(0, 0, 0, 0);
        [SerializeField] private LanmarkEnum landmark = LanmarkEnum.BuildingOne;
        public LatLng Position
        {
            get { return new LatLng(latNorth, lngEast); }
            private set 
            { 
                latNorth = (float) value.Latitude; 
                lngEast = (float) value.Longitude;
            }
        }

        public Quaternion Rotation
        {
            get { return rotation; }
            private set { rotation = value; }
        }

        public LanmarkEnum Landmark
        {
            get { return landmark; }
            private set { landmark = value; }
        }
    }

    [SerializeField] private LayerGameObjectPlacement[] _objectSpawners;

    [SerializeField] private SpawnPoint[] spawnPoints;

    private LatLng _spaceNeedleLatLng = new LatLng(47.620513f, -122.349303f);

    public enum LanmarkEnum
    {
        BuildingOne = 0,
        BuildingTwo = 1,
        BuildingThree = 2,
        BuildingFour = 3,
        BuildingBanana = 4,
    }

    private void Start()
    {
        BasicSpawnLandmarks();
    }

    private void BasicSpawnLandmarks()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            SpawnLandmark(spawnPoint.Position, spawnPoint.Rotation, spawnPoint.Landmark);
        }
    }

    /*// Just a silly method for testing
    private void SpawnInLine(float northSouth, float eastWest)
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnObejct(47.620513f, -122.349303f + i * 0.001f);
        }
    }*/

    private void SpawnLandmark(LatLng postion, Quaternion rotation, LanmarkEnum buildingType)
    {
        int buildingHash = buildingType.GetHashCode();

        LayerGameObjectPlacement objectSpawner = _objectSpawners[buildingHash];

        objectSpawner.PlaceInstance(postion, rotation);
    }
}
