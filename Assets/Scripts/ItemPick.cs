using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    [SerializeField] int counter;
    private scrFooterBar FooterScript;
    // Start is called before the first frame update
    void Start()
    {
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
	}
}
