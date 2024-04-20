using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI QuestText1;
    private bool Q1State = true;

    public TextMeshProUGUI QuestText2;
    public int Q2prog = 0;
    private bool Q2State = true;


    public TextMeshProUGUI QuestText3;
    private bool Q3State = true;


    public Seedling seedReward;

    public RankManager EXPSource;

    public CoinInventory CoinSource;

    public int EXPReward = 250;

    public int CoinReward = 5;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quest1Update()
    {
        if (Q1State == true)
        {
           
            QuestText1.text = "Quest Complete!";
            EXPSource.IncreaseEXP(EXPReward);
            CoinSource.AddCoins(CoinReward);
            seedReward.seedlingCount++;
            Q1State = false;
        }

    }

    public void Quest2Update()
    {
        if (Q2State == true)
        {


            Q2prog++;

            QuestText2.text = "Discover " + (3 - Q2prog) + " New Landmarks";

            if (Q2prog == 3)
            {
                QuestText2.text = "Quest Complete";
                EXPSource.IncreaseEXP(EXPReward);
                CoinSource.AddCoins(CoinReward);
                seedReward.seedlingCount++;
                Q2State = false;
            }
        }
    }

    public void Quest3Update()
    {
        if (Q3State == true)
        {


            QuestText3.text = "Quest Complete!";
            EXPSource.IncreaseEXP(EXPReward);
            CoinSource.AddCoins(CoinReward);
            seedReward.seedlingCount++;
            Q3State = false;
        }
    }

    //public void Reward(int EXP)
    //{
     //   EXPSource.currentEXP += EXP;
    //}
}
