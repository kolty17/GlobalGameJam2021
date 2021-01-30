using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float DeltaSalto = 1.0f;
    public float DeltaVelocita = 2.0f;
    public bool InVolo = false;
    public bool InMovimento = false;
    public Vector2 Forward;
    private Rigidbody2D rb;
    public float VelocityCap = 25.0f;
	
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
		
        Forward = Vector2.right;
		
    }

    private void FixedUpdate()
    {
        InMovimento = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.drag = 0;
            if (rb.velocity.magnitude <= VelocityCap)
            {
                rb.AddForce(Vector2.left * DeltaVelocita);
            }
            Forward = Vector2.left;
            InMovimento = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.drag = 0;
            if (rb.velocity.magnitude <= VelocityCap)
            {
                rb.AddForce(Vector2.right * DeltaVelocita);
            }
            Forward = Vector2.right;
            InMovimento = true;
        }
        
        if (Input.GetKey(KeyCode.Space) && !InVolo) //Salto
        {
            //Debug.Log("Salto");
            rb.AddForce(Vector3.up * DeltaSalto, ForceMode2D.Impulse);
            //InVolo = true;
            InMovimento = true;
        }
        if (!InMovimento)
		{
            rb.drag = 1;
        }
    }

}
