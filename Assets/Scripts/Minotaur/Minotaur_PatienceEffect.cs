using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_PatienceEffect : MonoBehaviour
{

    public float Minotaur_PatienceChange = 30.0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Minotaur")
        {

            collision.gameObject.GetComponent<Minotaur_Patience>().ChangePatience(Minotaur_PatienceChange);

            Destroy(this.gameObject);

        }

    }


}
