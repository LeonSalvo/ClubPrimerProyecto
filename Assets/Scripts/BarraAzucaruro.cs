using UnityEngine;
using UnityEngine.UI;

public class BarraAzucaruro : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxAzucaruro(int azucaruro)
    {
        slider.maxValue = azucaruro;
        slider.value = azucaruro;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetAzucaruro(int azucaruro)
    {
        slider.value = azucaruro;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

