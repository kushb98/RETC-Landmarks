using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoamlingCare : MonoBehaviour
{
    public Item roamling;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider happinessSlider;
    [SerializeField] private TextMeshProUGUI hungerText;
    [SerializeField] private TextMeshProUGUI happinessText;

    void Start()
    {
        hungerSlider.onValueChanged.AddListener((v) => { 
            hungerText.text = v.ToString("0");
        });
    }
         
  

}