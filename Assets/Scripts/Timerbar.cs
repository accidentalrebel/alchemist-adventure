using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timerbar : MonoBehaviour {

	// Use this for initialization
	
	public Transform bar;
	
	
	public void SetSize(float sizeNormalized) {
		bar.localScale = new Vector3 (sizeNormalized, 1f);
	}
	
}
