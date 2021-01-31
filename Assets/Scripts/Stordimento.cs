using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stordimento : MonoBehaviour
{
    [SerializeField] public float StunPoints = 0;
    [SerializeField] public float MaxStunPoints = 100f;
    [SerializeField] public float StunTime = 3f;
    public GameObject StunSprite;
    public bool Stunned = false;
    public float StunnedTime = 0f;
    private Rigidbody2D rb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StunPoints = 0;
        Stunned = false;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    public void StunDamage(float stunPoints)
    {
        StunPoints += stunPoints;
        if (StunPoints >= MaxStunPoints)
        {
            Stun();
        }
    }

    public bool IsStunned()
    {
        return Stunned;
    }

    private void Stun()
    {
        StunnedTime = StunTime;
        Stunned = true;
        StunPoints = 0;
        //Vector3 vec = new Vector3(transform.position.x + (3.2f * GetComponent<EnemyBehaviour>().direction.x), transform.position.y, transform.position.z);
        GameObject stunSprite = GameObject.Instantiate(StunSprite, transform.position + (GetComponent<EnemyBehaviour>().direction.normalized)*0.9f, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Stunned)
        {
            rb.velocity = Vector2.zero;
            StunnedTime -= Time.deltaTime;
            if (StunnedTime <= Mathf.Epsilon)
            {
                StunnedTime = 0;
                Stunned = false;
            }
        }
    }
}
