using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour2 : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1f;
    public float distance = 20;
    private bool movingRight = true;
    public Transform groundDetection;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInRange())
        {
            Move();
        }
    }

    private bool IsPlayerInRange()
    {
        return true;
    }
    private void Move()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (!groundInfo.collider)
        {
              if (movingRight)
               {
                   transform.eulerAngles = new Vector3(0, -180, 0);
                   movingRight = false;
               }
               else
               {
                   transform.eulerAngles = new Vector3(0, 0, 0);
                   movingRight = true;
               }
            //transform.rotation *= Quaternion.Euler(0, 180f, 0);

        }
    }
}