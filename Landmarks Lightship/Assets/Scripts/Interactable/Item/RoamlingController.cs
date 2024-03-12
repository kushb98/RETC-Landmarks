using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoamlingController : MonoBehaviour
{
    public Slider hungerSlider;
    public Slider happinessSlider;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI happinessText;
    public RectTransform hungerFillArea;
    public RectTransform happinessFillArea;

    // Reference to the Roamling (Item) scriptable object
    public Item roamling;

    void Start()
    {
        // Set the pivot of fill areas to the left side
        SetPivotToLeft(hungerFillArea);
        SetPivotToLeft(happinessFillArea);

        // Update UI based on Roamling values
        UpdateUI();
    }

    void SetPivotToLeft(RectTransform rectTransform)
    {
        rectTransform.pivot = new Vector2(0, 0.5f); // Pivot set to left side
    }

    void UpdateUI()
    {
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
        roamling.Happiness += (int)amount;
        UpdateUI(); // Update UI immediately
    }

    public void DecreaseHunger(float amount)
    {
        roamling.Hunger -= (int)amount;
        UpdateUI(); // Update UI immediately
    }
}
