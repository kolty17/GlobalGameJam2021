using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    public float DeltaSalto = 1.0f;
    public float DeltaVelocita = 1.0f;
    public float MoveSpeed = 1f;
    public float attackDistance = 200;
    //public bool InVolo = false;
    private Vector3 direction = Vector3.left;
    private float rotation = 0;
    private Rigidbody2D rb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsPlayerInRange())
        {
            Move();
        }
    }
    private bool IsPlayerInRange()
    {
        bool isPlayerInRange = false;
        if (Mathf.Abs(player.transform.position.x - transform.position.x) <= attackDistance)
        {
            isPlayerInRange = true;
        }
        return isPlayerInRange;
    }

    private void Move() //muove il nemico sulla piattaforma
    {
        rb.drag = 0;
        rb.velocity = direction;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        //rb.AddForce(direction * DeltaVelocita);
        //rb.AddForce(Vector3.up * DeltaSalto, ForceMode2D.Impulse);
        //if (!InMovimento) { rb.drag = 1; }
    }

    //TODO: funzione per attaccare il player e fare danno

    private void OnTriggerExit2D(Collider2D collision)
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
