using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerEnabler : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.transform.root.gameObject.CompareTag("Player"))
		{
			collision.gameObject.transform.root.gameObject.GetComponent<HungerPoint>().HungerEnabled = true;
			collision.gameObject.transform.root.gameObject.GetComponent<HungerPoint>().RestoreAll();
			Destroy(this.gameObject);
		}
	}
}
