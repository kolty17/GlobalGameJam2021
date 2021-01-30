using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]    
    public float DeltaSalto = 10.0f;
    //public float DeltaVelocita = 1.0f;
    public float SprintForce = 100;
    public float MoveSpeed = 1f;
    public float attackDistance = 15;
    public float playerKnockbackWhileMad = 100;
    //public bool InVolo = false;
    public Vector3 direction = Vector3.left;
    private float rotation = 0;
    private Rigidbody2D rb;
    private GameObject player;
    public bool onTheFloor = false;
    public float gravityScale = 1.0f;
    public Stordimento stordimento;
    public MeleeAttack attack;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        stordimento = GetComponent<Stordimento>();
        attack = GetComponentInChildren<MeleeAttack>();
    }

    private void Update()
    {
        if (onTheFloor)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            if (stordimento.IsStunned())
            {
                //rb.velocity = Vector2.zero;
                //stunned animation
            }
            else if (attack.IsMad())
            {
                ThisIsMaddness();
            }
            else if (IsPlayerInRange())
            {
                Move();
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
    }
    private bool IsPlayerInRange()
    {
        //bool isPlayerInRange = false;
        bool isPlayerInRange = true;
        if (player != null)
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) <= attackDistance)//ci entra anche se non in range
            {
                Debug.Log("Player in Range: " + (player.transform.position.x - transform.position.x).ToString());
                isPlayerInRange = true;
            }
        }
        return isPlayerInRange;
    }

    private void Move() //muove il nemico sulla piattaforma
    {
        rb.drag = 0;
        rb.velocity = (direction * MoveSpeed);
        transform.eulerAngles = new Vector3(0, rotation, 0);
        //rb.AddForce(direction * DeltaVelocita);
        //rb.AddForce(Vector3.up * DeltaSalto, ForceMode2D.Impulse);
        //if (!InMovimento) { rb.drag = 1; }
    }

    private void ThisIsMaddness()
    {
        float distance = (transform.position - player.transform.position).x;
        Vector3 playerDirection = (new Vector3(-distance,0,0)).normalized;
        rb.velocity = (playerDirection * MoveSpeed);
        rb.AddForce(playerDirection * SprintForce);
        direction = playerDirection;
        if (direction == Vector3.left)
        {
            rotation = 0;
        }
        else if(direction == Vector3.right)
        {
            rotation = -180;
        }
        transform.eulerAngles = new Vector3(0, rotation, 0);
        Debug.Log("PORCA PUTTANA: " + playerDirection);
    }

    //TODO: funzione per attaccare il player e fare danno

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (direction == Vector3.left)
            {
                rotation = -180;
                direction = Vector3.right;
            }
            else
            {
                direction = Vector3.left;
                rotation = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    /*private void OnTriggerEnter2D(Collider2D collider)
    {
        return;
    }*/


    //private void OnTriggerEnter2D(Collider2D collision) { InVolo = false; }
    /*[SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {//move right
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
    }*/
}
