using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField] private string fileName;
    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }



    private void Awake()
    {
        if (instance != null)
		{
			Debug.LogError("There is more than one DataPersistence in the scene");
        }
        instance = this;
}

    private void Start()
	{
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
		LoadGame();
	}

    public void NewGame()
    {
		gameData = new GameData();
	}

    public void LoadGame()
	{
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing to defaults");
            NewGame();  
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
            Debug.Log("test");
        }

        Debug.Log("Loaded Coin count = " + gameData._numCoins);
    }

    public void SaveGame()
    {
          foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved Coin count = " + gameData._numCoins);

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
	{
		SaveGame();
	}

    private List<IDataPersistence> FindAllDataPersistenceObjects()
	{
		IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();

        Debug.Log("Found " + dataPersistenceObjects.Count() + " data persistence objects");
        return new List <IDataPersistence>(dataPersistenceObjects);
        
	}

}

