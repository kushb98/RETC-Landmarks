using UnityEngine;

public class ItemDetailsCanvas : MonoBehaviour
{
    public void ShowCanvas()
    {
        gameObject.SetActive(true);
    }

    public void HideCanvas()
    {
        gameObject.SetActive(false);
    }
}
