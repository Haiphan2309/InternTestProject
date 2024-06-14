using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHpSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text hpText;

    public EventHandler<int> changeHpEvent;
    public EventHandler<int> changeMaxHpEvent;

    [SerializeField] Image fillImage;
    [SerializeField] Gradient gradient;

    public void Setup()
    {
        changeMaxHpEvent += SetMaxHp;
        changeHpEvent += SetHp;
    }
    void SetMaxHp(object sender, int maxHp)
    {
        slider.maxValue = maxHp;
    }
    void SetHp(object sender, int hp)
    {
        slider.value = hp;
        hpText.text = hp.ToString() + " / " + slider.maxValue.ToString();


        float normalizedHealth = slider.value / slider.maxValue;
        fillImage.color = gradient.Evaluate(normalizedHealth);
    }
}
