using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_FollowPlayer_Lerp : MonoBehaviour
{

    private GameObject Player;

    public float Minotaur_FoPl_LerpSpeed = 0.1f;
    public float Minotaur_FoPl_DistanceForLerpStart = 3.0f;
    private bool Minotaur_FoPl_IsLerping = false;
    public float Minotaur_FoPl_DistanceForLerpStop = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.Find("Player");
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (!Minotaur_FoPl_IsLerping)
        {

            if (Vector3.Distance(transform.position, Player.transform.position) > Minotaur_FoPl_DistanceForLerpStart)
            {
                Minotaur_FoPl_IsLerping = true;
            }

        }

        if (Minotaur_FoPl_IsLerping)
        {

            transform.position = Vector3.Lerp(transform.position, Player.transform.position, Minotaur_FoPl_LerpSpeed);

            if (Vector3.Distance(transform.position, Player.transform.position) <= Minotaur_FoPl_DistanceForLerpStop)
            {
                Minotaur_FoPl_IsLerping = false;
            }

        }

    }

}
