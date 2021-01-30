using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PavementCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            return;
        }
        GetComponentInParent<PlayerMovement>().InVolo = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            return;
        }
        GetComponentInParent<PlayerMovement>().InVolo = false;
    }

}
