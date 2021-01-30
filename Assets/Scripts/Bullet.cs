using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float Damage = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log("collision: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("EnemyBody"))
        {
            LifePoint LifePointScript = collision.gameObject.GetComponentInParent<LifePoint>();
            if (LifePointScript)
            {
                LifePointScript.Damage(Damage);
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Platform"))
		{
            GetComponent<Rigidbody2D>().drag = 1;
		}
    }
	
}
