using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSlider : MonoBehaviour
{
    public Slider slider;

    public void SetMaxSpawnTime(float max)
    {
        slider.maxValue = max;
        slider.value = max;
    }

    public void SetSpawnTime(float hp)
    {
        slider.value = hp;
    }
}
