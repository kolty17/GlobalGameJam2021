using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSync : MonoBehaviour
{
    private GameObject Player;
    private Slider slider;
    void Start()
    {
        Player = GameObject.Find("Player");
        slider = GetComponent<Slider>();
        slider.maxValue = Player.GetComponent<LifePoint>().HPMax;
    }

    void Update()
    {
        slider.value = Player.GetComponent<LifePoint>().HP;
    }
}
