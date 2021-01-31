using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    [SerializeField] public float JumpDelta = 99999f;
    Stordimento stordimento;
    void Start()
    {
        Debug.Log("PLATFORM CREATED");
        stordimento = GetComponentInParent<Stordimento>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stordimento.IsStunned())
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyPlatform()
    {
        Debug.Log("PLATFORM DESTROYED");
        Destroy(this.gameObject);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("DATTEBAYO!");
            //Rigidbody2D rb = collision.gameObject.transform.root.gameObject.GetComponent<Rigidbody2D>();
            //rb.velocity = Vector2.zero;
            //rb.AddForce(Vector3.up * JumpDelta, ForceMode2D.Impulse);
        }
    }
}
