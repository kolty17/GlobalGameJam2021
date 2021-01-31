using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    [SerializeField] int counter;
    private scrFooterBar FooterScript;
    public bool MinotaurPickable = true;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("UI - FooterBar") == null)
        {
            this.enabled = false;
            return;
        }
        FooterScript = GameObject.Find("UI - FooterBar").GetComponent<scrFooterBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.transform.root.gameObject.CompareTag("Player"))
		{
            switch(counter)
			{
                case 1: 
                    break;
                case 2:
                    Inventory.IncreaseQuantity(2);
                    //FooterScript.SetObject(2, FooterScript.ItemArray[1].GetComponent<SpriteRenderer>().sprite, Inventory.GetQuantity(2));
                    FooterScript.UpdateCounter(2);
                    Destroy(this.gameObject);
                    break;
                case 3: 
                    break;
                case 4: 
                    break;
                case 5: 
                    break;
            }
        }
        else if ((collision.gameObject.transform.root.gameObject.CompareTag("Platform") ||
                 (collision.gameObject.transform.root.gameObject.CompareTag("Wall"))))
		{
            MinotaurPickable = false;

        }
        else if (collision.gameObject.transform.root.gameObject.CompareTag("Minotaur"))
		{
            //Debug.Log("Preso al volo dal minotauro");
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if ((collision.gameObject.transform.root.gameObject.CompareTag("Platform") ||
                 (collision.gameObject.transform.root.gameObject.CompareTag("Wall"))))
        {

            MinotaurPickable = false;

            Minotaur_PatienceEffect patienceEffectScript = this.gameObject.GetComponent<Minotaur_PatienceEffect>();
            if (patienceEffectScript != null)
            {
                Destroy(patienceEffectScript);
            }

        }
    }
}
