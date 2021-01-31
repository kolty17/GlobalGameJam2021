using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrAnim : MonoBehaviour
{
    public GameObject rigidbodyPersonaggio;
    public GameObject spritePersonaggio;
    public Sprite Mossa1;
    public Sprite Mossa2;
    public Sprite Salto;

    private float nextActionTime = 0.0f;
    public float period = 10f;

    private bool switcher;

    // Start is called before the first frame update
    void Start()
    {
        switcher = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbodyPersonaggio.GetComponent<PlayerMovement>().InVolo == true){
            spritePersonaggio.GetComponent<SpriteRenderer>().sprite = Salto;
        }
        else {
            if (Time.time > nextActionTime)
            {
                Debug.Log("time passed");
                if (rigidbodyPersonaggio.GetComponent<Rigidbody2D>().velocity.magnitude > 0.01f)
                {
                    Debug.Log("in motion");
                    nextActionTime = Time.time + period;
                    switcher = !switcher;
                }
            }

            if (switcher == true) spritePersonaggio.GetComponent<SpriteRenderer>().sprite = Mossa1;
            if (switcher == false) spritePersonaggio.GetComponent<SpriteRenderer>().sprite = Mossa2;
        }
    }
}
