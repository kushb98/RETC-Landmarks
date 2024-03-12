using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StreetName : InteractableObject
{
    [Header("Rewards")]
    [SerializeField] private int coinReward = 2;
    [SerializeField] private int expReward = 300;

    [Header("Settings")]
    [SerializeField] private Color readyColor = Color.yellow;
    [SerializeField] private Color consumedColor = Color.gray;
    [SerializeField] private Color outOfRangeColor = Color.black;

    [Header("References")]
    [SerializeField] private TextMeshPro nameText;

    [Header("References")]
    [SerializeField] public string Familiarity;
    [SerializeField] private int visits;
    [SerializeField] public float visitDelay = 20f;
    [SerializeField] private float timeSinceVisit;
    int previousVisits;

    protected override void Start()
    {
        base.Start();

        visitDelay = 1f;
        
        nameText.color = outOfRangeColor;
    }

    public override void Select(WorldInteractor worldInteractor)
    {
        base.Select(worldInteractor);
        print("Is Selected");
        previousVisits = visits;

        if (timeSinceVisit >= visitDelay)
            
            visits++;

        if (visits >= 6)
        {
            RankManager.Singleton.IncreaseEXP(300);
            Familiarity = "Familiar";
        }
        else if (visits == 2)
        {
            RankManager.Singleton.IncreaseEXP(500);
            Familiarity = "First Encounter";
        }


        else if (visits < 6 && visits > 1)
        {
            RankManager.Singleton.IncreaseEXP(100);
            Familiarity = "Discovered";
        }

    }


    public override void Deselect()
    {
        base.Deselect();

        if (previousVisits != visits)
            timeSinceVisit = 0;
    }

    // Resets the street name and makes it available for use again
    protected override void MakeReady()
    { 
        base.MakeReady();
        
        nameText.color = readyColor;
    }

    protected override void Consume()
    {
        base.Consume();
        
        nameText.color = consumedColor;

        CoinInventory.Singleton.AddCoins(coinReward);
        RankManager.Singleton.IncreaseEXP(expReward);

        


    }

    protected override void OnOutOfRange()
    {
        base.OnOutOfRange();
        
        nameText.color = outOfRangeColor;
    }

    protected override void OnInRange()
    {
        base.OnInRange();
        if (visits == 0)
            visits++; 
            RankManager.Singleton.IncreaseEXP(100);
            Familiarity = "First Encounter";
            
        
        if (_ready)
            nameText.color = readyColor;
        else
            nameText.color = consumedColor;
    }

    private void Update()
    {
        
        if (visits > 0)
            timeSinceVisit = timeSinceVisit + Time.deltaTime;
    }
}
