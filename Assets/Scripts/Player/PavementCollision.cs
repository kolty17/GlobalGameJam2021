using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PavementCollision : MonoBehaviour
{

    private Player_MinotaurFollowPoints Player_FollowPointsScript;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            return;
        }
        Player_FollowPointsScript.Player_FollowPointCreation_Timer_Actual = Player_FollowPointsScript.Player_FollowPointCreation_Timer;
        Player_FollowPointsScript.SpawnFollowPoint(true, true);
        GetComponentInParent<PlayerMovement>().InVolo = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            return;
        }
        Player_FollowPointsScript.Player_FollowPointCreation_Timer_Actual = Player_FollowPointsScript.Player_FollowPointCreation_Timer;
        if (GetComponentInParent<PlayerMovement>().InVolo)
        {
            Player_FollowPointsScript.SpawnFollowPoint(true, true);
        }
        else
        {
            Player_FollowPointsScript.SpawnFollowPoint(false, true);
        }
        GetComponentInParent<PlayerMovement>().InVolo = false;
    }

}
