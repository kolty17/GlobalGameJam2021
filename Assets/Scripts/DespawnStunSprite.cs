using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnStunSprite : MonoBehaviour
{
    private Stordimento stun;
    // Start is called before the first frame update
    void Start()
    {
        stun = GetComponentInParent<Stordimento>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stun.IsStunned())
        {
            Destroy(this.gameObject);
        }
    }
}
