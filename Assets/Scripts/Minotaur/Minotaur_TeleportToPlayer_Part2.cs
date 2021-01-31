using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_TeleportToPlayer_Part2 : MonoBehaviour
{

    [HideInInspector] public Minotaur_FollowPlayer FollowPlayerScript;
    [HideInInspector] public Player_MinotaurFollowPoints MinotaurFollowPointsScript;

    [HideInInspector] public GameObject LastInstancedPoint = null;

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("2");
        LastInstancedPoint.transform.parent = MinotaurFollowPointsScript.Player_FollowPoints_Container.transform;

        FollowPlayerScript.enabled = true;

        FollowPlayerScript.Minotaur_FoPl_LerpStartPosition = MinotaurFollowPointsScript.Player_FollowPoints_LastInstancedPoint_Position;
        FollowPlayerScript.Minotaur_FoPl_LerpTimer = 0.0f;

        FollowPlayerScript.Minotaur_FoPl_PointToReach = null;
        FollowPlayerScript.Minotaur_LastFramePosition = MinotaurFollowPointsScript.Player_FollowPoints_LastInstancedPoint_Position;

        LastInstancedPoint = null;

        this.enabled = false;

    }

}
