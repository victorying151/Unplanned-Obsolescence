using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Enemy boss;

    void Start(){
        slider.maxValue = boss.health;
        slider.value = slider.maxValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Update()
    {
        
    }
}
