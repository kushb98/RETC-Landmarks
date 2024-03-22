using UnityEngine;

public class RoamlingManager : MonoBehaviour
{
    // Reference to Roamling scriptable objects
    public Roamling axolotlPrefab;
    public Roamling bearPrefab;
    public Roamling turtlePrefab;

    void Start()
    {
        // Example: Instantiate Roamlings when the game starts
        InstantiateRoamling(axolotlPrefab);
        InstantiateRoamling(bearPrefab);
        InstantiateRoamling(turtlePrefab);
    }

    void InstantiateRoamling(Roamling roamlingPrefab)
    {
        // Instantiate a Roamling object based on the Roamling prefab
        Roamling roamlingInstance = Instantiate(roamlingPrefab);

        // Perform additional setup if needed (e.g., position, UI display)
        // ...

        // Print the Roamling's name as a confirmation
        Debug.Log("Instantiated Roamling: " + roamlingInstance.roamlingName);
    }
}
