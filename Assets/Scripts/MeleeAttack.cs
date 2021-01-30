using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField]
    public float knockbackIntensity = 200f;
    public float knockbackIntensityWhileMad = 500f;
    public float meleeDamage = 10.0f;

    [SerializeField]
    public int hitBeforeGettingMad = 2;
    public float madnessTotalTime = 1f;
    public int hit = 0;
    public float madnessCounter = 0;
    public bool isMad = false;
    private Rigidbody2D parentRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        parentRigidbody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMad())
        {
            madnessCounter -= Time.deltaTime;
            if (madnessCounter <= Mathf.Epsilon)
            {
                madnessCounter = 0;
                isMad = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) //Damaging Player
        {
            if (GetComponentInParent<EnemyBehaviour>().attack.IsMad())
            {
                GetComponentInParent<EnemyBehaviour>().attack.Chill();
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(GetComponentInParent<EnemyBehaviour>().direction * knockbackIntensityWhileMad);
            }
            else
            {
                Vector3 direction;
                if (transform.position.x > col.gameObject.transform.position.x)
                {
                     direction = Vector3.left;
                }
                else
                {
                    direction = Vector3.right;
                }
                col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(direction * knockbackIntensity);
                col.gameObject.GetComponentInParent<LifePoint>().Damage(meleeDamage);
            }
        }
        else if (col.gameObject.CompareTag("Platform"))
        {
            parentRigidbody.velocity = new Vector2(parentRigidbody.velocity.x, 0);
            GetComponentInParent<EnemyBehaviour>().onTheFloor = true;
        }
        else if (col.gameObject.CompareTag("Projectile"))
        {
            HitHandler();
        }
    }

    public bool IsMad()
    {
        return isMad;
    }
    public void Chill()
    {
        isMad = false;
    }
    private void HitHandler()
    {
        Debug.Log("PROJECTILE COLLIDED WITH ENEMY");
        hit++;
        if (hit >= hitBeforeGettingMad)
        {
            //animazione 
            isMad = true;
            madnessCounter = madnessTotalTime;
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
