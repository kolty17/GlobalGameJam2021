using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    public float destructionTime = 0.5f;

	// Update is called once per frame
	void Update () {

        destructionTime -= Time.deltaTime;

        if (destructionTime <= 0.0f)
        {
            Destroy(this.gameObject);
        }

	}
}
