using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Battle_npc : MonoBehaviour  {
	
	//References
	public StatClass stats;
	public Timerbar timerbar;
	public Battle_npc[] heroes;
	public Battle_npc enemy;
	
	public GameObject damagecounterenemy;
	public TMP_Text damagetoenemy;
	public TMP_Text damagetohero1;
	public TMP_Text damagetohero2;
	public TMP_Text damagetohero3;
	
	public float damagetime = 0;
	public bool hasAttacked = false;
	
  
	
	public void Setup(StatClass stats) {
		this.stats = stats;
		stats.TIMER = stats.SPD;
	}
	
	void Start() {
		
		Debug.Log("battle start");

	}

	protected void Update () {
		if (stats == null) {
			return;
		}
		
		//Turns
		stats.TIMER -= Time.deltaTime;
		
		if ( stats.TIMER <= 0 ) {
			
			Debug.Log("hero " + stats.NAME + " turn finished");
			
			//Hero Attacks
			if ( this.gameObject.tag == "Player") {
				hasAttacked = true;	
				OnAttackHero();
				
			}
	
			//Enemy Attacks
			if ( this.gameObject.tag == "Enemy") {
				OnAttackEnemy();
			}
			
			stats.TIMER = stats.SPD;
		}
		
		//Damage Counter Enemy
		/*if (hasAttacked = true) {
			damagecounterenemy.gameObject.SetActive(true);
			damagetime = 2;
			damagetime -= Time.deltaTime;
			if (damagetime <= 0 ) {	
				damagecounterenemy.gameObject.SetActive(false);
			}
			hasAttacked = false;
		}
		*/
		
		
		//Timer Bar
		timerbar.SetSize((stats.TIMER/stats.SPD));
		
		//Damage and Death
		if (stats.HP <= 0 ) {
			Death();
		}	
	}
	
	public void OnAttackHero () {
		
		enemy.stats.HP -= this.stats.PWR;
		Debug.Log("hero " + stats.NAME + " attacked the enemy");
		damagetoenemy.text = this.stats.PWR.ToString();
		damagecounterenemy.gameObject.SetActive(true);
		for (float damagetime = 2; damagetime <= 0; damagetime -= Time.deltaTime ) {
		damagecounterenemy.gameObject.SetActive(false);}
		
	}
	
	public void OnAttackEnemy () {
		
		heroes[Random.Range(0,3)].stats.HP -= this.stats.PWR;
		Debug.Log(stats.NAME + " attacked the hero");
		
	}
	
	public void Death() {

        Destroy(this.gameObject);
		Debug.Log ( stats.NAME + "is dead");
		
	}
	
	
	

	
}
