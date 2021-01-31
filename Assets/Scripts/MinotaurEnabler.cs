using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurEnabler : MonoBehaviour
{
    [SerializeField] public GameObject Minotaur;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.root.gameObject.CompareTag("Player"))
        {
            Minotaur.GetComponent<SpriteRenderer>().enabled = true;
            Minotaur.GetComponent<Animator>().enabled = true;
            Minotaur.GetComponent<BoxCollider2D>().enabled = true;
            Minotaur.transform.Find("Body_Container/Body").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Minotaur.transform.Find("Minotaur_Expression").gameObject.GetComponent<Animator>().enabled = true;
            Minotaur.transform.Find("Minotaur_Expression/1").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Minotaur.transform.Find("Minotaur_Expression/2").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Minotaur.transform.Find("Minotaur_Expression/3").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
