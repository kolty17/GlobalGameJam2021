using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_FallCheck : MonoBehaviour
{

    [HideInInspector] public Minotaur_Charging Minotaur_ChargingScript;
    [HideInInspector] public bool IsRunning = false;
    [HideInInspector] public bool IsGrounded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            IsGrounded = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        /*if (collision.gameObject.CompareTag("Platform") && IsRunning)
        {
            Minotaur_ChargingScript.Minotaur_ChargeOrEscape_TimeBeforeRecover = 0.0f;
            IsRunning = false;
        }*/
        if (collision.gameObject.CompareTag("Platform"))
        {

            if (IsRunning)
            {
                Minotaur_ChargingScript.Minotaur_ChargeOrEscape_TimeBeforeRecover = 0.0f;
                IsRunning = false;
                IsGrounded = true;
            }
            else
            {
                IsGrounded = false;
            }

        }

    }

}
