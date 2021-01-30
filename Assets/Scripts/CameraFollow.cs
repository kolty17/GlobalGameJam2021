using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target;
    public float ZDistanceToTarget = -20.0f;

    void LateUpdate()
    {
        transform.position = new Vector3(Target.transform.position.x, transform.position.y, ZDistanceToTarget);
    }
}
