using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerSync : MonoBehaviour
{
    private GameObject Player;
    private Slider slider;
    private GameObject FillArea;
    void Start()
    {
        Player = GameObject.Find("Player");
        slider = GetComponent<Slider>();
        slider.maxValue = Player.GetComponent<HungerPoint>().HungerMax;
		FillArea = transform.Find("Fill Area").gameObject;
    }

    void Update()
    {
        slider.value = Player.GetComponent<HungerPoint>().Hunger;
        FillArea.SetActive(Player.GetComponent<HungerPoint>().Hunger > 0);
    }
}
