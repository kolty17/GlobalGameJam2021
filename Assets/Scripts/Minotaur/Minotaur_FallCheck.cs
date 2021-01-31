using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_FallCheck : MonoBehaviour
{

    [HideInInspector] public Minotaur_Charging Minotaur_ChargingScript;
    [HideInInspector] public bool IsRunning = false;

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Platform") && IsRunning)
        {
            Minotaur_ChargingScript.Minotaur_ChargeOrEscape_TimeBeforeRecover = 0.0f;
            IsRunning = false;
        }

    }

}
