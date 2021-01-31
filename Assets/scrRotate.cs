using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRotate : MonoBehaviour
{
    public bool senso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (senso) transform.Rotate(0, 0, 0.2f, Space.World);
        else transform.Rotate(0, 0, -0.2f, Space.World);
    }
}
