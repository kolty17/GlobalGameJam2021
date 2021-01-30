using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_PatienceEffect : MonoBehaviour
{

    public float Minotaur_PatienceChange = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Minotaur")
        {

            collision.gameObject.GetComponent<Minotaur_Patience>().Minotaur_PatiencePoints_Actual += Minotaur_PatienceChange;
            if (Minotaur_PatienceChange >= 0.0f)
            {

            }
            else
            {

            }

        }

    }


}
