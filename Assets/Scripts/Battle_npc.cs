using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_npc : MonoBehaviour  {
	
	//References
	public StatClass stats;
	public SpriteRenderer timerBar;
	public float originalXPosition;
	public Battle_npc[] heroes;
	public Battle_npc enemy;
  
	
	public void Setup(StatClass stats) {
		this.stats = stats;
		stats.TIMER = stats.SPD;
	}
	
	void Start() {
		
		Debug.Log("battle start");
		originalXPosition = timerBar.transform.localPosition.x;
			
	}

	protected void Update () {
		if (stats == null) {
			return;
		}
		
		stats.TIMER -= Time.deltaTime;
		
		if ( stats.TIMER <= 0 ) {
			
			Debug.Log("hero " + stats.NAME + " turn finished");
			
			//Hero Attacks
			if ( this.gameObject.tag == "Player") {
				OnAttackHero();
			}
			
			//Enemy Attacks
			if ( this.gameObject.tag == "Enemy") {
				OnAttackEnemy();
			}
			
			stats.TIMER = stats.SPD;
		}
		
		//Timer Bar
		timerBar.transform.localScale = new Vector3 (((stats.TIMER/stats.SPD)*0.19f), 0.02f, 0.2f);
		
		
	}
	
	public void OnAttackHero () {
		
		enemy.stats.HP -= this.stats.PWR;
		Debug.Log("hero " + stats.NAME + " attacked the enemy");
		
	}
	
	public void OnAttackEnemy () {
		
		heroes[Random.Range(0,2)].stats.HP -= this.stats.PWR;
		Debug.Log(stats.NAME + " attacked the hero");
		
	}
	
	public void Death() {
 
		if(stats.HP <= 0)
		{
          Destroy(this.gameObject);
		}
	}
	
	

	
}
