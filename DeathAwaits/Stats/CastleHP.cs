using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHP : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float max)
    {
        slider.maxValue = max;
        slider.value = max;
    }

    public void SetHealth(float hp)
    {
        slider.value = hp;
    }
}
