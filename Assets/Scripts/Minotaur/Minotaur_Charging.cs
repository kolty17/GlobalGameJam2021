using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] public class Minotaur_ChargeInfo
{

    public GlobalVars.PlayerRelationship RelationshipForActivation = GlobalVars.PlayerRelationship.Neutral;

    [Space(10)]
    public int RockHitsForActivation = 3;

    [Space(10)]
    public float ChargeAtPlayer_Chance = 50.0f;
    public int ChargeAtPlayer_DamageToPlayer = 2;
    public float ChargeAtPlayer_RagePreparationTimer = 2.0f;
    public float ChargeAtPlayer_ChargeSpeed = 10.0f;
    public float ChargeAtPlayer_RecoverTimer = 3.0f;
    public float ChargeAtPlayer_TimeBeforeRecover = 4.0f;

    [Space(10)]
    public int EscapeFromPlayer_DamageToPlayer = 1;
    public float EscapeFromPlayer_EscapeSpeed = 10.0f;
    public float EscapeFromPlayer_RecoverTimer = 3.0f;
    public float EscapeFromPlayer_TimeBeforeRecover = 4.0f;

    public Minotaur_ChargeInfo (GlobalVars.PlayerRelationship NewRelationshipForActivation)
    {
        RelationshipForActivation = NewRelationshipForActivation;
    }

}


public class Minotaur_Charging : MonoBehaviour
{

    private Minotaur_Patience Minotaur_PatienceScript;
    private Animator Minotaur_Animator;
    private Transform Minotaur_BodyContainer;
    private Minotaur_FollowPlayer Minotaur_FollowPlayerScript;

    private Minotaur_FallCheck Minotaur_FallCheckScript;

    public List<Minotaur_ChargeInfo> Minotaur_ChargeInfo_List = new List<Minotaur_ChargeInfo> { new Minotaur_ChargeInfo (GlobalVars.PlayerRelationship.Love), new Minotaur_ChargeInfo(GlobalVars.PlayerRelationship.Like), new Minotaur_ChargeInfo(GlobalVars.PlayerRelationship.Neutral), new Minotaur_ChargeInfo(GlobalVars.PlayerRelationship.Dislike), new Minotaur_ChargeInfo(GlobalVars.PlayerRelationship.Hate) };

    [HideInInspector] public int Minotaur_RocksBeforeCharge = 3;
    private bool Minotaur_StartCharge = false;

    private bool Minotaur_ChargeOrNot = false;

    private int Minotaur_ChargeOrEscape_DamageToPlayer = 2;
    private float Minotaur_ChargeOrEscape_PreparationTimer = 2.0f;
    private float Minotaur_ChargeOrEscape_MovementSpeed = 10.0f;
    private float Minotaur_ChargeOrEscape_RecoverTimer = 3.0f;
    [HideInInspector] public float Minotaur_ChargeOrEscape_TimeBeforeRecover = 4.0f;

    // Start is called before the first frame update
    void Start()
    {

        Minotaur_PatienceScript = this.gameObject.GetComponent<Minotaur_Patience>();
        Minotaur_Animator = this.gameObject.gameObject.GetComponent<Animator>();

        /*Minotaur_BodyContainer = transform.Find("Body_Container");
        Minotaur_FallCheckScript = Minotaur_BodyContainer.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Minotaur_FallCheck>();*/
        Minotaur_BodyContainer = this.gameObject.transform;
        Minotaur_FallCheckScript = Minotaur_BodyContainer.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Minotaur_FallCheck>();
        Minotaur_FallCheckScript.Minotaur_ChargingScript = this;

        Minotaur_FollowPlayerScript = this.gameObject.GetComponent<Minotaur_FollowPlayer>();

        foreach (Minotaur_ChargeInfo chargeInfo in Minotaur_ChargeInfo_List)
        {

            if (chargeInfo.RelationshipForActivation == Minotaur_PatienceScript.Minotaur_PlayerRelationship)
            {
                Minotaur_RocksBeforeCharge = chargeInfo.RockHitsForActivation;
                break;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!Minotaur_StartCharge)
        {

            if (Minotaur_RocksBeforeCharge <= 0)// && !Minotaur_FollowPlayerScript.Minotaur_FoPl_IsJumping)
            {

                Minotaur_PatienceScript.CheckRelationship();
                foreach (Minotaur_ChargeInfo chargeInfo in Minotaur_ChargeInfo_List)
                {

                    if (chargeInfo.RelationshipForActivation == Minotaur_PatienceScript.Minotaur_PlayerRelationship)
                    {

                        float randomNumber = UnityEngine.Random.Range(0.0f, 100.0f);
                        float chargeChance = chargeInfo.ChargeAtPlayer_Chance;

                        if (randomNumber <= chargeChance)
                        {

                            Minotaur_ChargeOrNot = true;

                            Minotaur_ChargeOrEscape_DamageToPlayer = chargeInfo.ChargeAtPlayer_DamageToPlayer;
                            Minotaur_ChargeOrEscape_PreparationTimer = Mathf.Abs(chargeInfo.ChargeAtPlayer_RagePreparationTimer);
                            Minotaur_ChargeOrEscape_MovementSpeed = chargeInfo.ChargeAtPlayer_ChargeSpeed;
                            Minotaur_ChargeOrEscape_RecoverTimer = chargeInfo.ChargeAtPlayer_RecoverTimer;
                            Minotaur_ChargeOrEscape_TimeBeforeRecover = chargeInfo.ChargeAtPlayer_TimeBeforeRecover;

                        }
                        else
                        {

                            Minotaur_ChargeOrNot = false;

                            Minotaur_ChargeOrEscape_DamageToPlayer = chargeInfo.EscapeFromPlayer_DamageToPlayer;
                            Minotaur_ChargeOrEscape_PreparationTimer = 0.0f;
                            Minotaur_ChargeOrEscape_MovementSpeed = chargeInfo.EscapeFromPlayer_EscapeSpeed;
                            Minotaur_ChargeOrEscape_RecoverTimer = chargeInfo.EscapeFromPlayer_RecoverTimer;
                            Minotaur_ChargeOrEscape_TimeBeforeRecover = chargeInfo.EscapeFromPlayer_TimeBeforeRecover;

                        }

                        break;

                    }

                }

                Minotaur_FollowPlayerScript.enabled = false;

                Minotaur_StartCharge = true;

            }

        }
        else
        {

            if (Minotaur_ChargeOrEscape_PreparationTimer < 0.0f)
            {

                if (Minotaur_ChargeOrEscape_TimeBeforeRecover <= 0.0f)
                {

                    Minotaur_FallCheckScript.gameObject.transform.localPosition = new Vector3(0.0f, Minotaur_FallCheckScript.gameObject.transform.localPosition.y, 0.0f);
                    Minotaur_FallCheckScript.IsRunning = false;

                    Minotaur_Animator.SetBool("IsRaging", false);
                    Minotaur_Animator.SetBool("IsCharging", false);

                    if (Minotaur_ChargeOrEscape_RecoverTimer <= 0.0f)
                    {

                        /*Minotaur_PatienceScript.CheckRelationship();
                        foreach (Minotaur_ChargeInfo chargeInfo in Minotaur_ChargeInfo_List)
                        {

                            if (chargeInfo.RelationshipForActivation == Minotaur_PatienceScript.Minotaur_PlayerRelationship)
                            {
                                Minotaur_RocksBeforeCharge = chargeInfo.RockHitsForActivation;

                                break;
                            }

                        }

                        Minotaur_FollowPlayerScript.enabled = true;

                        Minotaur_StartCharge = false;*/


                        Minotaur_Animator.SetTrigger("IsDisappearing");

                        Minotaur_PatienceScript.CheckRelationship();
                        foreach (Minotaur_ChargeInfo chargeInfo in Minotaur_ChargeInfo_List)
                        {

                            if (chargeInfo.RelationshipForActivation == Minotaur_PatienceScript.Minotaur_PlayerRelationship)
                            {
                                Minotaur_RocksBeforeCharge = chargeInfo.RockHitsForActivation;

                                break;
                            }

                        }

                        Minotaur_StartCharge = false;

                    }
                    else
                    {
                        Minotaur_Animator.SetBool("IsWalking", false);

                        Minotaur_ChargeOrEscape_RecoverTimer -= Time.deltaTime;
                    }

                }
                else
                {
                    //transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(Minotaur_ChargeOrEscape_MovementSpeed * Time.deltaTime, 0.0f, 0.0f), );
                    transform.position += new Vector3(Minotaur_ChargeOrEscape_MovementSpeed * Time.deltaTime, 0.0f, 0.0f);

                    Minotaur_ChargeOrEscape_TimeBeforeRecover -= Time.deltaTime;
                }

            }
            else
            {

                Minotaur_FallCheckScript.gameObject.transform.localPosition = new Vector3(0.0f, Minotaur_FallCheckScript.gameObject.transform.localPosition.y, 0.0f);
                Minotaur_FallCheckScript.IsRunning = false;

                if (Minotaur_ChargeOrNot)
                {
                    Minotaur_Animator.SetBool("IsRaging", true);
                }

                Minotaur_ChargeOrEscape_PreparationTimer -= Time.deltaTime;
                if (Minotaur_ChargeOrEscape_PreparationTimer <= 0.0f)
                {

                    if (Minotaur_ChargeOrNot)
                    {

                        Minotaur_Animator.SetBool("IsRaging", false);
                        Minotaur_Animator.SetBool("IsCharging", true);

                        if (Minotaur_PatienceScript.Player.transform.position.x < transform.position.x)
                        {
                            Minotaur_BodyContainer.localScale = new Vector3(-Mathf.Abs(Minotaur_BodyContainer.localScale.x), Minotaur_BodyContainer.localScale.y, Minotaur_BodyContainer.localScale.z);
                            Minotaur_ChargeOrEscape_MovementSpeed = -Mathf.Abs(Minotaur_ChargeOrEscape_MovementSpeed);
                        }
                        else if (Minotaur_PatienceScript.Player.transform.position.x > transform.position.x)
                        {
                            Minotaur_BodyContainer.localScale = new Vector3(Mathf.Abs(Minotaur_BodyContainer.localScale.x), Minotaur_BodyContainer.localScale.y, Minotaur_BodyContainer.localScale.z);
                        }

                    }
                    else
                    {

                        Minotaur_Animator.SetBool("IsRaging", false);
                        Minotaur_Animator.SetBool("IsWalking", true);

                        if (Minotaur_PatienceScript.Player.transform.position.x < transform.position.x)
                        {
                            Minotaur_BodyContainer.localScale = new Vector3(Mathf.Abs(Minotaur_BodyContainer.localScale.x), Minotaur_BodyContainer.localScale.y, Minotaur_BodyContainer.localScale.z);
                        }
                        else if (Minotaur_PatienceScript.Player.transform.position.x > transform.position.x)
                        {
                            Minotaur_BodyContainer.localScale = new Vector3(-Mathf.Abs(Minotaur_BodyContainer.localScale.x), Minotaur_BodyContainer.localScale.y, Minotaur_BodyContainer.localScale.z);
                            Minotaur_ChargeOrEscape_MovementSpeed = -Mathf.Abs(Minotaur_ChargeOrEscape_MovementSpeed);
                        }

                    }

                    Minotaur_FallCheckScript.gameObject.transform.localPosition = new Vector3(Mathf.Abs(Minotaur_ChargeOrEscape_MovementSpeed) / 10.0f, Minotaur_FallCheckScript.gameObject.transform.localPosition.y, 0.0f);
                    Minotaur_FallCheckScript.IsRunning = true;

                }

            }

        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (Minotaur_StartCharge)
        {

            if (Minotaur_ChargeOrEscape_PreparationTimer <= 0.0f && Minotaur_ChargeOrEscape_TimeBeforeRecover > 0.0f)
            {

                if (collision.gameObject.CompareTag("PlayerBody"))
                {
                    collision.gameObject.transform.parent.parent.gameObject.GetComponent<LifePoint>().HP -= Minotaur_ChargeOrEscape_DamageToPlayer;
                }
                if (collision.gameObject.CompareTag("EnemyBody"))
                {
                    Destroy(collision.gameObject.transform.parent.gameObject);
                }

            }

        }

    }


}
