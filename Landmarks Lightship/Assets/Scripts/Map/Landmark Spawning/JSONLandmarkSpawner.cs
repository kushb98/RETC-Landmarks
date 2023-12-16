using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static CoordinateSpawner;
using Niantic.Lightship.Maps.Core.Coordinates;

public class JSONLandmarkSpawner : MonoBehaviour
{
    /// <summary>
    /// Data structure containing all the landmarks to be spawnned on the map.
    /// Inteded to be stored and read from a JSON file.
    /// </summary>
    public class LandmarksList
    {
        public int count;
        public float[] latNorth;
        public float[] lngEast;
        public LanmarkEnum[] landmark; // Maybe this needs to be an int or string?
    }

/*    /// <summary>
    /// A single landmark to be spawnned on the map, and its location.
    /// </summary>
    public class LandmarkSpawnPoint
    {
        public float latNorth;
        public float lngEast;
        public LanmarkEnum landmark; // Maybe this needs to be an int or string?
    }*/

    [SerializeField] private CoordinateSpawner coordinateSpawner;
    private LandmarksList landmarksList;

    private void Start()
    {
        landmarksList = new LandmarksList();
        landmarksList = LoadFromJSON("Resources/JSON Files/landmarksList.txt");

        if (landmarksList != null)
        {
            for (int i = 0; i < landmarksList.count; i++)
            {
                coordinateSpawner.SpawnLandmark(new LatLng(landmarksList.latNorth[i], landmarksList.lngEast[i]), Quaternion.identity, landmarksList.landmark[i]);
            }

        }
    }


    private void CreateTestDocument()
    {
        LandmarksList landmarksList = new LandmarksList();
        landmarksList.count = 3;
        landmarksList.latNorth = new float[3] { 47.6205f, 47.6205f, 47.6205f };
        landmarksList.lngEast = new float[3] { -122.3493f, -122.3493f, -122.3493f };
        landmarksList.landmark = new LanmarkEnum[3] { LanmarkEnum.BuildingOne, LanmarkEnum.BuildingTwo, LanmarkEnum.BuildingThree};

        string json = JsonUtility.ToJson(landmarksList);
        File.WriteAllText(Application.dataPath + "/Resources/JSON Files/landmarksList.txt", json);
        Debug.Log("Created JSON file: " + json);
    }



    public LandmarksList LoadFromJSON(string filePath)
    {
        landmarksList = new LandmarksList();

        if (File.Exists(Application.dataPath + "/" + filePath))
        {
            string json = File.ReadAllText(Application.dataPath + "/" + filePath);

            landmarksList = JsonUtility.FromJson<LandmarksList>(json);
            Debug.Log("Loaded JSON file: " + json);
        }
        else
        {
            Debug.LogError("No file found at Assets/" + filePath);
            return null;
        }

        return landmarksList;
    }
}
