using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BarBase : MonoBehaviour
{
    public Slider Slider;
    public Color low;
    public Color high;

    public virtual void SetBar(int Current , int Max)
    {
        Slider.value = Current;
        Slider.maxValue = Max;

        Slider.fillRect.GetComponent<Image>().color = Color.Lerp(low, high, Slider.normalizedValue);
    }
}
