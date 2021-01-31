using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockEnabler : MonoBehaviour
{
	private scrFooterBar FooterScript;

	private void Start()
	{
		FooterScript = GameObject.Find("UI - FooterBar").GetComponent<scrFooterBar>();
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.transform.root.gameObject.CompareTag("Player"))
		{
			Debug.Log("LET'S ROCK!");
			Inventory.IncreaseQuantity(1);
			FooterScript.UpdateCounter(1);
			Destroy(this.gameObject);
		}	
	}
}
