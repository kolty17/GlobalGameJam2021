using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stordimento : MonoBehaviour
{
    [SerializeField] public float StunPoints;
    [SerializeField] public float MaxStunPoints = 100f;
    [SerializeField] public float StunTime = 3f;
    public bool Stunned = false;
    public float StunnedTime = 0;
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
        Stunned = true;
        StunPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Stunned)
        {
            StunnedTime -= Time.deltaTime;
            if (StunnedTime <= 0f)
            {
                StunnedTime = 0;
                Stunned = false;
            }
        }
    }
}
