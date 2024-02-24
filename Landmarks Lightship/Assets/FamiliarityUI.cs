using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FamiliarityUI : MonoBehaviour
{

    public TextMeshProUGUI familiarityDisplay;

    public WorldInteractor _WorldInteractor;

    string tempFamiliarity = "None";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetFamiliarity()
    {
        
        familiarityDisplay.text = "Familiarity: " +  _WorldInteractor.currentStreetName.Familiarity;

        
    }


    // Update is called once per frame
    void Update()
    {

        

    }
}
