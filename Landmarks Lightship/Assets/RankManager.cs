using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankManager : MonoBehaviour
{
    public static RankManager Singleton;

    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider expSlider;

    private int currentRank = 1;
    private int currentEXP = 0;
    private int expRequired = 2000; // Initial EXP required
    private int maxRank = 10; // Maximum rank
    private int maxEXP = 20000; // Maximum EXP
    private int expIncreaseOnMouseClick = 100; // Amount of EXP to increase on mouse click

    private string[] rankNames = { "Scout", "Pathfinder", "Adventurer", "Trailblazer" };
    private int[] rankExpThresholds = { 6000, 12000, 18000, 20000 }; // EXP thresholds for rank names

    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
    /*  if (Input.GetMouseButtonDown(0)) // Check if the left mouse button is clicked
        {
            IncreaseEXP(expIncreaseOnMouseClick); // Increase EXP when clicked
        }*/
    }

    public void IncreaseEXP(int amount)
    {
        currentEXP += amount;

        // Check for rank advancement
        while (currentRank < maxRank && currentEXP >= expRequired)
        {
            currentRank++;
            currentEXP -= expRequired;
            expRequired = currentRank * 2000; // Update EXP required for the next rank
        }

        // Ensure EXP doesn't exceed the maximum
        currentEXP = Mathf.Clamp(currentEXP, 0, maxEXP);

        // Update the slider's value based on currentEXP and expRequired
        float progress = (float)currentEXP / expRequired;
        expSlider.value = progress;

        UpdateUI();
    }

    private void UpdateUI()
    {
        string rankName = "None";

        if (currentRank >= 1 && currentRank <= 3)
        {
            rankName = "Scout";
        }
        else if (currentRank >= 4 && currentRank <= 6)
        {
            rankName = "Pathfinder";
        }
        else if (currentRank >= 7 && currentRank <= 9)
        {
            rankName = "Adventurer";
        }
        else if (currentRank == 10)
        {
            rankName = "Trailblazer";
        }

        rankText.text = "Rank: " + rankName;
        expText.text = "EXP: " + currentEXP + " / " + expRequired;
        levelText.text = "Level: " + currentRank;
    }
}
