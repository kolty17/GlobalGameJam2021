using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaBackgroundY : MonoBehaviour
{
    public GameObject Target;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Target.transform.position.y, transform.position.z);
    }
}
