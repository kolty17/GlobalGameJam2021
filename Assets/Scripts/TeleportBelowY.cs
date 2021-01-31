using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBelowY : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] public float MinY;
    void Update()
    {
        if (!Target) return;
        if (Target.transform.position.y < MinY)
		{
            if (Target.GetComponent<Rigidbody2D>())
			{
                Target.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            Target.transform.position = transform.position;
		}
    }
}
