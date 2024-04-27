using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoamlingController : MonoBehaviour
{
    public Slider hungerSlider;
    public Slider happinessSlider;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI happinessText;
    public RectTransform hungerFillArea;
    public RectTransform happinessFillArea;
    private AudioManager audioManager;

    private Item roamling;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        // Set the pivot of fill areas to the left side
        SetPivotToLeft(hungerFillArea);
        SetPivotToLeft(happinessFillArea);

        // Update UI based on Roamling values
        UpdateUI();
    }

    public void UpdateRoamlingStats(Item roamling) 
    {
        this.roamling = roamling; // Update the reference to the current roamling
        // Update roamling name
        nameText.text = roamling.itemName;

        // Update hunger slider and text
        hungerSlider.maxValue = roamling.maxHunger;
        hungerSlider.value = roamling.Hunger;
        hungerText.text = $"Hunger: {roamling.Hunger}";

        // Update happiness slider and text
        happinessSlider.maxValue = roamling.maxHappiness;
        happinessSlider.value = roamling.Happiness;
        happinessText.text = $"Happiness: {roamling.Happiness}";

        
        

        
    }

    void SetPivotToLeft(RectTransform rectTransform)
    {
        rectTransform.pivot = new Vector2(0, 0.5f); // Pivot set to left side
    }

    void UpdateUI()
    {
        if (roamling == null) 
            
        return; // Return if roamling is not assigned

        // Normalize values between 0 and 1 using maxHunger and maxHappiness
        float normalizedHunger = NormalizeValue(roamling.Hunger, 0, roamling.maxHunger);
        float normalizedHappiness = NormalizeValue(roamling.Happiness, 0, roamling.maxHappiness);

        // Update hunger slider and text
        UpdateSlider(hungerSlider, normalizedHunger, roamling.Hunger, hungerText, hungerFillArea);

        // Update happiness slider and text
        UpdateSlider(happinessSlider, normalizedHappiness, roamling.Happiness, happinessText, happinessFillArea);
    }

    void UpdateSlider(Slider slider, float normalizedValue, int value, TextMeshProUGUI text, RectTransform fillArea)
    {
        // Update slider value and text
        slider.value = normalizedValue;
        text.text = $"{slider.name}: {value}";

        // Calculate the width of the fill area based on normalized value
        float fillAreaWidth = normalizedValue * slider.GetComponent<RectTransform>().rect.width;

        // Adjust only the fill area size, keeping the slider handle fixed
        fillArea.sizeDelta = new Vector2(fillAreaWidth, fillArea.sizeDelta.y);
    }

    float NormalizeValue(float value, float minValue, float maxValue)
    {
        return Mathf.Clamp01((value - minValue) / (maxValue - minValue));
    }

    public void IncreaseHappiness(float amount)
    {
        if (roamling == null)
            return;

        if (roamling.Happiness >= roamling.maxHappiness)
            return;

        roamling.Happiness += (int)amount;
        UpdateRoamlingStats(roamling); 
        audioManager.Play(audioManager.roamlingHappy);

    }

    public void DecreaseHunger(float amount)
    {
        if (roamling == null)
            return;

        if (roamling.Hunger <= 0)
            return;

        roamling.Hunger -= (int)amount;
        UpdateRoamlingStats(roamling); // Update UI with new stats
    }
}
