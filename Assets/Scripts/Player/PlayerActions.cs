using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] public GameObject Projectile;
    [SerializeField] public float ThrowForce = 10.0f;
    [SerializeField] public float ThrowDelay = 0.5f;
    private float Timer = 0f;
    private bool CanThrow = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanThrow)
        {
            Timer += Time.deltaTime;
            if (Timer > ThrowDelay)
            {
                Timer = 0;
                CanThrow = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && CanThrow)
		{
            CanThrow = false;
            GameObject Proiettile = GameObject.Instantiate(Projectile, transform.position,Quaternion.identity,transform.root.parent);
            Vector2 Velocity = new Vector2(GetComponentInParent<Rigidbody2D>().velocity.x, 0);
            Proiettile.GetComponent<Rigidbody2D>().AddForce(Velocity + GetComponentInParent<PlayerMovement>().Forward * ThrowForce, ForceMode2D.Impulse);

		}
    }
}