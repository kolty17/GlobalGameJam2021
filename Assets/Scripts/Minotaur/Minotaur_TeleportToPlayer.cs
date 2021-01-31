using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_TeleportToPlayer : MonoBehaviour
{

    [HideInInspector] public bool TeleportToPlayer = false;

    [HideInInspector] public GameObject Player;
    [HideInInspector] public Minotaur_FollowPlayer FollowPlayerScript;
    [HideInInspector] public Player_MinotaurFollowPoints MinotaurFollowPointsScript;

    [HideInInspector] public GameObject LastInstancedPoint = null;

    void Update()
    {
        
        if (TeleportToPlayer)
        {

            /*if (LastInstancedPoint == null)
            {
                Teleport();
            }
            else
            {

                Debug.Log("2");
                LastInstancedPoint.transform.parent = MinotaurFollowPointsScript.Player_FollowPoints_Container.transform.parent;

                FollowPlayerScript.enabled = true;

                FollowPlayerScript.Minotaur_FoPl_LerpStartPosition = MinotaurFollowPointsScript.Player_FollowPoints_LastInstancedPoint_Position;
                FollowPlayerScript.Minotaur_FoPl_LerpTimer = 0.0f;

                LastInstancedPoint = null;

                TeleportToPlayer = false;

                this.enabled = false;

            }*/

            Teleport();

            this.gameObject.GetComponent<Minotaur_TeleportToPlayer_Part2>().enabled = true;
            this.gameObject.GetComponent<Minotaur_TeleportToPlayer_Part2>().FollowPlayerScript = FollowPlayerScript;
            this.gameObject.GetComponent<Minotaur_TeleportToPlayer_Part2>().MinotaurFollowPointsScript = MinotaurFollowPointsScript;
            this.gameObject.GetComponent<Minotaur_TeleportToPlayer_Part2>().LastInstancedPoint = LastInstancedPoint;

            LastInstancedPoint = null;

            TeleportToPlayer = false;

            this.enabled = false;

        }

    }

    public void Teleport()
    {

        Debug.Log("Teleport()");
        //transform.position = Player.transform.position;
        LastInstancedPoint = Instantiate(MinotaurFollowPointsScript.Player_FollowPoints_LastInstancedPoint, MinotaurFollowPointsScript.Player_FollowPoints_LastInstancedPoint_Position, Quaternion.Euler(Vector3.zero));
        transform.position = MinotaurFollowPointsScript.Player_FollowPoints_LastInstancedPoint_Position;

        MinotaurFollowPointsScript.Player_FollowPoints_PathLength = Vector3.Distance(Player.transform.position, MinotaurFollowPointsScript.Player_FollowPoints_LastInstancedPoint_Position);
        Destroy(MinotaurFollowPointsScript.Player_FollowPoints_Container);

        MinotaurFollowPointsScript.Player_FollowPoints_LastInstancedPoint = LastInstancedPoint;

        MinotaurFollowPointsScript.Player_FollowPoints_Container = new GameObject()
        {
            name = "FollowPointsContainer"
        };
        MinotaurFollowPointsScript.Player_FollowPoints_Container.transform.position = Vector3.zero;
        /*lastInstancedPoint.transform.parent = MinotaurFollowPointsScript.Player_FollowPoints_Container.transform.parent;

        FollowPlayerScript.enabled = true;

        FollowPlayerScript.Minotaur_FoPl_LerpStartPosition = MinotaurFollowPointsScript.Player_FollowPoints_LastInstancedPoint_Position;
        FollowPlayerScript.Minotaur_FoPl_LerpTimer = 0.0f;*/

    }

}
