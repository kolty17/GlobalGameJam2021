using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField]
    public float knockbackIntensity = 1.0f;
    public float meleeDamage = 10.0f;
    private Rigidbody2D parentRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        parentRigidbody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) //Damaging Player
        {
            if(transform.position.x > col.gameObject.transform.position.x)
            {
                col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(Vector3.left * knockbackIntensity);
            }
            else
            {
                col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(Vector3.right * knockbackIntensity);
            }
            col.gameObject.GetComponentInParent<LifePoint>().Damage(meleeDamage);
        }
        else if (col.gameObject.CompareTag("Platform"))
        {
            parentRigidbody.velocity = new Vector2(parentRigidbody.velocity.x, 0);
            GetComponentInParent<EnemyBehaviour>().onTheFloor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            parentRigidbody.velocity = new Vector2(parentRigidbody.velocity.x, 0);
            GetComponentInParent<EnemyBehaviour>().onTheFloor = false;
        }
    }

}
