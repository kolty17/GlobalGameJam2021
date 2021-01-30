using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PavementCollision_FirstFrame : MonoBehaviour
{

    private Player_MinotaurFollowPoints Player_FollowPointsScript;
    private bool Player_FirstFrameDone = false;
    private bool Player_IsFlying = true;

    // Start is called before the first frame update
    void Start()
    {
        Transform playerParentObject = transform.parent.parent;
        if (playerParentObject == null)
        {
            Debug.LogError("NON HO TROVATO IL PLAYER");
        }
        Player_FollowPointsScript = playerParentObject.Find("FollowPointsSpawner").GetComponent<Player_MinotaurFollowPoints>();
    }


    void LateUpdate()
    {

        if (Player_FirstFrameDone)
        {

            if (Player_IsFlying)
            {
                Debug.Log("OVENEONFOEFN");
                Player_FollowPointsScript.Player_FollowPointCreation_Timer_Actual = Player_FollowPointsScript.Player_FollowPointCreation_Timer;
                Player_FollowPointsScript.SpawnFollowPoint(true, true);
                GetComponentInParent<PlayerMovement>().InVolo = true;
            }

            Destroy(this);

        }
        else
        {
            Player_FirstFrameDone = true;
        }

    }


    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            return;
        }
        Player_IsFlying = false;

    }

}
