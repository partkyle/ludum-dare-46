using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;

    public float total;
    public float current;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.maxValue = total;
        slider.value = current;
    }
}
