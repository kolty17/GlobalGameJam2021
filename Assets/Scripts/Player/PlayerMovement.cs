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
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InMovimento = true;
        if (Input.GetKey(KeyCode.A))
        {
            rb.drag = 0;
            rb.AddForce(Vector3.left * DeltaVelocita);
            InMovimento = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.drag = 0;
            rb.AddForce(Vector3.right * DeltaVelocita);
            InMovimento = true;
        }
        if (Input.GetKey(KeyCode.Space) && !InVolo) //Salto
        {
            rb.AddForce(Vector3.up * DeltaSalto, ForceMode2D.Impulse);
            //InVolo = true;
            InMovimento = true;
        }
        if (!InMovimento)
		{
            rb.drag = 1;
        }
    }
    /*
    private void OnCollisionExit2D(Collision2D collision)
	{
        InVolo = false;
        if (collision.gameObject.CompareTag("Platform"))
		{
            if (transform.position.y>collision.gameObject.transform.position.y) //dall'alto
			{
                Debug.Log("dall'alto");
                InVolo = false;
                rb.drag = 0;
            }
		}
	}
    */
}
