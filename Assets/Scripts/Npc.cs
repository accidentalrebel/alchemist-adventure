using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour  {
	
	public StatClass stats;
	
	public void Setup(StatClass stats) {
		this.stats = stats;
		stats.TIMER = stats.SPD;
	}
	
	void Start() {
		
		
		
	}
	// Update is called once per frame
	protected void Update () {
		if (stats == null) {
			return;
		}
		
		stats.TIMER -= Time.deltaTime;
		
		if ( stats.TIMER <= 0 ) {
			//character action
			Debug.Log("hero " + stats.NAME + " turn finished");

			stats.TIMER = stats.SPD;
		}
		
	}
	

	
}
