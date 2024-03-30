using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI QuestText1;

    public TextMeshProUGUI QuestText2;
    public int Q2prog = 0;

    public TextMeshProUGUI QuestText3;

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
        QuestText1.text = "Quest Complete!";
        EXPSource.IncreaseEXP(EXPReward);
        CoinSource.AddCoins(CoinReward);

    }

    public void Quest2Update()
    {
        Q2prog++;

        QuestText2.text = "Discover " + (3 - Q2prog) + " New Landmarks";

        if (Q2prog >= 3)
        {
            QuestText2.text = "Quest Complete";
            EXPSource.IncreaseEXP(EXPReward);
            CoinSource.AddCoins(CoinReward);
        }
    }

    public void Quest3Update()
    {
        QuestText3.text = "Quest Complete!";
        EXPSource.IncreaseEXP(EXPReward);
        CoinSource.AddCoins(CoinReward);
    }

    //public void Reward(int EXP)
    //{
     //   EXPSource.currentEXP += EXP;
    //}
}
