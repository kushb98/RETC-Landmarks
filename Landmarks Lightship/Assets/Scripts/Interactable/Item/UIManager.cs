using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hungerSlider;
    public Slider happinessSlider;

    public void UpdateUI(Item item)
    {
        hungerSlider.value = item.Hunger;
        happinessSlider.value = item.Happiness;
    }
    public void UpdateUI(Roamling roamling)
    {
        hungerSlider.value = roamling.Hunger;
        happinessSlider.value = roamling.Happiness;
    }

    public void UpdateRoamlingUI(Roamling roamling)
    {
        hungerSlider.value = roamling.Hunger;
        happinessSlider.value = roamling.Happiness;
    }
}
