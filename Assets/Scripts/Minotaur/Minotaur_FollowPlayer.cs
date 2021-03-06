using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_FollowPlayer : MonoBehaviour
{

    private GameObject Player;
    private Player_MinotaurFollowPoints Player_FollowPointsScript;
    private Animator Minotaur_Anims_Animator;
    private Transform Minotaur_BodyContainer;
    private Minotaur_FallCheck Minotaur_PlatformCheckScript;

    [HideInInspector] public bool Minotaur_FoPl_IsJumping = false;

    /*[HideInInspector]*/
    public GameObject Minotaur_FoPl_PointToReach;

    [HideInInspector] public float Minotaur_FoPl_LerpTimer = 0.0f;
    private float Minotaur_FoPl_ActualLerpSpeed = 8f;
    public float Minotaur_FoPl_LerpSpeed = 8f; //MEMO: (1 / Minotaur_FoPl_LerpSpeed) � il tempo che gli ci vuole per raggiungere il successivo punto
    public float Minotuar_FoPl_JumpLerpSpeed = 9.0f;
    [HideInInspector] public Vector3 Minotaur_FoPl_LerpStartPosition;
    private bool Minotaur_FoPl_IsFollowing = false;

    public float Minotaur_FoPl_PathDistanceForFollow = 3.0f;
    public float Minotaur_FoPl_DistanceForStop = 2.0f;
    public float Minotaur_FoPl_CoverDistance_PathDistanceForNewSpeed = 8.0f;
    public float Minotaur_FoPl_CoverDistance_NewLerpSpeed = 12.0f;
    public float Minotaur_FoPl_CoverDistance_PathDistanceForBackToNormalSpeed = 3.0f;

    [HideInInspector] public Vector3 Minotaur_LastFramePosition;

    private float Minotaur_FoPl_SafetyCheck_OnGround_Timer = 1.0f;
    private float Minotaur_FoPl_SafetyCheck_OnGround_Timer_Actual = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        //Application.targetFrameRate = 60;

        Player = GameObject.FindGameObjectWithTag("Player");
        Player_FollowPointsScript = Player.transform.Find("FollowPointsSpawner").gameObject.GetComponent<Player_MinotaurFollowPoints>();
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z);

        Minotaur_FoPl_ActualLerpSpeed = Minotaur_FoPl_LerpSpeed;

        Minotaur_Anims_Animator = this.gameObject.GetComponent<Animator>();

        Minotaur_BodyContainer = this.gameObject.transform;//transform.Find("Body_Container");

        Minotaur_PlatformCheckScript = transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Minotaur_FallCheck>();

        this.gameObject.GetComponent<Minotaur_TeleportToPlayer>().Player = Player;
        this.gameObject.GetComponent<Minotaur_TeleportToPlayer>().FollowPlayerScript = this;

        Minotaur_LastFramePosition = transform.position;

        Minotaur_FoPl_SafetyCheck_OnGround_Timer_Actual = Minotaur_FoPl_SafetyCheck_OnGround_Timer;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log(Minotaur_FoPl_IsFollowing + "; " + Minotaur_FoPl_IsJumping);// + "; " + Minotaur_FoPl_PointToReach.transform.position);
        if (Minotaur_FoPl_PointToReach != null)
        {

            if (!Minotaur_FoPl_IsJumping)
            {

                if (!Minotaur_FoPl_IsFollowing)
                {

                    if (Player_FollowPointsScript.Player_FollowPoints_PathLength >= Minotaur_FoPl_PathDistanceForFollow)
                    {
                        Minotaur_FoPl_IsFollowing = true;
                    }
                    else
                    {
                        Minotaur_Anims_Animator.SetBool("IsWalking", false);
                    }

                }
                else
                {

                    Minotaur_Anims_Animator.SetBool("IsWalking", true);
                    transform.position = Vector3.Lerp(Minotaur_FoPl_LerpStartPosition, Minotaur_FoPl_PointToReach.transform.position, Minotaur_FoPl_LerpTimer);
                    //Debug.Log(Minotaur_FoPl_LerpStartPosition + "; " + Minotaur_FoPl_PointToReach.transform.position + "; " + Minotaur_FoPl_LerpTimer);

                    float lastFrameMovementLength = Vector3.Distance(transform.position, Minotaur_LastFramePosition);
                    //Debug.Log(lastFrameMovementLength + "; " + Player_FollowPointsScript.Player_FollowPoints_PathLength);
                    Player_FollowPointsScript.Player_FollowPoints_PathLength -= lastFrameMovementLength;
                    //Debug.Log(Player_FollowPointsScript.Player_FollowPoints_PathLength);

                    if (Player_FollowPointsScript.Player_FollowPoints_PathLength <= Minotaur_FoPl_DistanceForStop)
                    {
                        //Debug.Log("1");
                        Minotaur_FoPl_IsFollowing = false;
                        Minotaur_Anims_Animator.SetBool("IsWalking", false);
                    }
                    else
                    {

                        //Debug.Log("2");
                        /*float lastFrameMovementLength = Vector3.Distance(transform.position, Minotaur_LastFramePosition);
                        Player_FollowPointsScript.Player_FollowPoints_PathLength -= lastFrameMovementLength;*/

                        if (Minotaur_FoPl_ActualLerpSpeed != Minotaur_FoPl_CoverDistance_NewLerpSpeed)
                        {

                            if (Player_FollowPointsScript.Player_FollowPoints_PathLength >= Minotaur_FoPl_CoverDistance_PathDistanceForNewSpeed)
                            {
                                Minotaur_FoPl_ActualLerpSpeed = Minotaur_FoPl_CoverDistance_NewLerpSpeed;
                            }
                            else
                            {
                                Minotaur_FoPl_ActualLerpSpeed = Minotaur_FoPl_LerpSpeed;
                            }

                        }
                        else
                        {

                            if (Player_FollowPointsScript.Player_FollowPoints_PathLength <= Minotaur_FoPl_CoverDistance_PathDistanceForBackToNormalSpeed)
                            {
                                Minotaur_FoPl_ActualLerpSpeed = Minotaur_FoPl_LerpSpeed;
                            }
                            else
                            {
                                Minotaur_FoPl_ActualLerpSpeed = Minotaur_FoPl_CoverDistance_NewLerpSpeed;
                            }

                        }

                        Minotaur_FoPl_LerpTimer += (Minotaur_FoPl_ActualLerpSpeed * Time.deltaTime);
                        if (Minotaur_FoPl_LerpTimer + (Minotaur_FoPl_ActualLerpSpeed * Time.deltaTime) >= 1.0f) //MEMO: la ripetizione non � un errore, voglio davvero controllare cosa succede il frame successivo
                        {

                            GameObject nextPoint = Minotaur_FoPl_PointToReach.GetComponent<Minotaur_FollowPoint>().FollowPoint_Next;

                            if (Minotaur_FoPl_PointToReach.GetComponent<Minotaur_FollowPoint>().FollowPoint_ToggleJump)
                            {
                                Minotaur_FoPl_IsJumping = true;
                            }

                            Destroy(Minotaur_FoPl_PointToReach);
                            if (nextPoint != null)
                            {
                                Minotaur_FoPl_PointToReach = nextPoint;

                                if (nextPoint.transform.position.x < transform.position.x)
                                {
                                    Minotaur_BodyContainer.localScale = new Vector3(-Mathf.Abs(Minotaur_BodyContainer.localScale.x), Minotaur_BodyContainer.localScale.y, Minotaur_BodyContainer.localScale.z);
                                }
                                else if (nextPoint.transform.position.x > transform.position.x)
                                {
                                    Minotaur_BodyContainer.localScale = new Vector3(Mathf.Abs(Minotaur_BodyContainer.localScale.x), Minotaur_BodyContainer.localScale.y, Minotaur_BodyContainer.localScale.z);
                                }

                            }
                            else
                            {
                                Minotaur_Anims_Animator.SetBool("IsWalking", false);
                                Minotaur_FoPl_PointToReach = null;
                            }

                            Minotaur_FoPl_LerpStartPosition = transform.position;

                            Minotaur_FoPl_LerpTimer = 0.0f;

                        }

                    }

                    Minotaur_LastFramePosition = transform.position;

                }

            }
            else
            {

                //Debug.Log("!!!!!");
                Minotaur_Anims_Animator.SetBool("IsWalking", true);
                //Minotaur_Anims_Animator.SetBool("IsJumping", true);
                transform.position = Vector3.Lerp(Minotaur_FoPl_LerpStartPosition, Minotaur_FoPl_PointToReach.transform.position, Minotaur_FoPl_LerpTimer);

                float lastFrameMovementLength = Vector3.Distance(transform.position, Minotaur_LastFramePosition);
                Player_FollowPointsScript.Player_FollowPoints_PathLength -= lastFrameMovementLength;

                if (Minotaur_FoPl_LerpTimer < 1.0f)
                {
                    Minotaur_FoPl_LerpTimer += (Minotuar_FoPl_JumpLerpSpeed * Time.deltaTime);
                }
                else if (Minotaur_FoPl_LerpTimer > 1.0f)
                {
                    Minotaur_FoPl_LerpTimer = 1.0f;
                }
                else
                {
                    //Debug.Log("????");
                    GameObject nextPoint = Minotaur_FoPl_PointToReach.GetComponent<Minotaur_FollowPoint>().FollowPoint_Next;

                    if (Minotaur_FoPl_PointToReach.GetComponent<Minotaur_FollowPoint>().FollowPoint_ToggleJump)
                    {
                        Minotaur_FoPl_IsJumping = false;
                        if (nextPoint != null)
                        {
                            Minotaur_FoPl_IsFollowing = true;
                        }
                    }

                    Destroy(Minotaur_FoPl_PointToReach);
                    if (nextPoint != null)
                    {
                        Minotaur_FoPl_PointToReach = nextPoint;

                        if (nextPoint.transform.position.x < transform.position.x)
                        {
                            Minotaur_BodyContainer.localScale = new Vector3(-Mathf.Abs(Minotaur_BodyContainer.localScale.x), Minotaur_BodyContainer.localScale.y, Minotaur_BodyContainer.localScale.z);
                        }
                        else if (nextPoint.transform.position.x > transform.position.x)
                        {
                            Minotaur_BodyContainer.localScale = new Vector3(Mathf.Abs(Minotaur_BodyContainer.localScale.x), Minotaur_BodyContainer.localScale.y, Minotaur_BodyContainer.localScale.z);
                        }

                    }
                    else
                    {
                        Minotaur_Anims_Animator.SetBool("IsWalking", false);
                        //Minotaur_Anims_Animator.SetBool("IsJumping", false);
                        Minotaur_FoPl_PointToReach = null;
                    }

                    Minotaur_FoPl_LerpStartPosition = transform.position;

                    Minotaur_FoPl_LerpTimer = 0.0f;

                }

                Minotaur_LastFramePosition = transform.position;

            }

        }


        Minotaur_FoPl_SafetyCheck_OnGround_Timer_Actual -= Time.deltaTime;
        if (Minotaur_FoPl_SafetyCheck_OnGround_Timer_Actual <= 0.0f)
        {

            if (!Player.GetComponent<PlayerMovement>().InVolo && Minotaur_PlatformCheckScript.IsGrounded)
            {
                Minotaur_FoPl_IsJumping = false;
            }
            //Minotaur_FoPl_IsJumping = Minotaur_PlatformCheckScript.IsGrounded; //Player.GetComponent<PlayerMovement>().InVolo;

            Minotaur_FoPl_SafetyCheck_OnGround_Timer_Actual = Minotaur_FoPl_SafetyCheck_OnGround_Timer;

        }


    }

}
