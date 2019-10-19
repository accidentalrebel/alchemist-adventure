using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounterTimer : MonoBehaviour {
	
float damagetime = 1f;
	
	void Update () {
	
		damagetime -= Time.deltaTime;
		if ( damagetime <= 0 ) {	
			Debug.Log("ouch!");
			Destroy(this.gameObject);
		}
	}
}
