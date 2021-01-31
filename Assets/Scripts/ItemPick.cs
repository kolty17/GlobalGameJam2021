using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    [SerializeField] int counter;
    private scrFooterBar FooterScript;
    public bool ToccatoTerra = false;
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

    void _Collision(GameObject TargetGameObject)
	{
        if (TargetGameObject.CompareTag("Player") && (ToccatoTerra))
        {
            switch (counter)
            {
                case 1:
                    break;
                case 2:
                    Inventory.IncreaseQuantity(2);
                    if (Inventory.NoFoodPicked)
					{
                        FooterScript.SetObject(2, FooterScript.ItemArray[1].GetComponent<SpriteRenderer>().sprite, Inventory.GetQuantity(2));
                        Inventory.NoFoodPicked = false;
                    }
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
        else if ((TargetGameObject.CompareTag("Platform") ||
                 (TargetGameObject.CompareTag("Wall"))))
        {
            ToccatoTerra = true;

        }
        else if (TargetGameObject.CompareTag("Minotaur"))
        {
            Debug.Log("Preso al volo dal minotauro");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
	{
        _Collision(collision.gameObject.transform.root.gameObject);
        /*
        if (collision.gameObject.transform.root.gameObject.CompareTag("Player") && (ToccatoTerra))
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
            ToccatoTerra = true;

        }
        else if (collision.gameObject.transform.root.gameObject.CompareTag("Minotaur"))
		{
            Debug.Log("Preso al volo dal minotauro");
		}
        */
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        _Collision(collision.gameObject.transform.root.gameObject);
        /*
        if ((collision.gameObject.transform.root.gameObject.CompareTag("Platform") ||
                 (collision.gameObject.transform.root.gameObject.CompareTag("Wall"))))
        {

            ToccatoTerra = true;

            Minotaur_PatienceEffect patienceEffectScript = this.gameObject.GetComponent<Minotaur_PatienceEffect>();
            if (patienceEffectScript != null)
            {
                Destroy(patienceEffectScript);
            }

        }
        */
    }
}
