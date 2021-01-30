using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSync : MonoBehaviour
{
    private GameObject Player;
    private Slider slider;
    private GameObject FillArea;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //GameObject.Find("Player");
        slider = GetComponent<Slider>();
        slider.maxValue = Player.GetComponent<LifePoint>().HPMax;
        FillArea = transform.Find("Fill Area").gameObject;
    }

    void Update()
    {
        slider.value = Player.GetComponent<LifePoint>().HP;
        FillArea.SetActive(Player.GetComponent<LifePoint>().HP > 0);
    }
}
