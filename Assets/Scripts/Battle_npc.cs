using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Battle_npc : MonoBehaviour  {
	
	//References
	public StatClass stats;
	public Ailments ailments;
	public Timerbar timerbar;
	public Battle_npc[] heroes; //<-- hero array reference
	public Battle_npc enemy;
	public Transform canvas;
	
	public TMP_Text damagePrefab;
	public TMP_Text poisonPrefab;
	public bool isDead = false;
	//int bonusPWR = 2; << BONUSPOWER 
	
  
	
	public void Setup(StatClass stats) {
		this.stats = stats;
		stats.TIMER = stats.SPD;
	}
	
	protected void Start() {
		
		Debug.Log("battle start");


	}

	protected void Update () {
		if (stats == null) {
			return;
		}
		
		//Turns
		stats.TIMER -= Time.deltaTime;
		
		if ( stats.TIMER <= 0 ) {
			
			
			//Hero Attacks
			if ( this.gameObject.tag == "Player") {
				if (this.stats.STATUS == "NA" ) {
					onAttackHero();
				}
				
				if ( this.stats.STATUS == "PSN" ) {
					onAttackHero();
					ailments.isPoisoned(this);
				}
			}
	
			//Enemy Attacks
			if ( this.gameObject.tag == "Enemy") {
				
				//if ( this.stats.HP > this.stats.MaxHP * 0.75f ) {
				//onAttackEnemy();
				//}
				//else {
					Battle_npc target = onAttackEnemy ();
					ailments.poisonAttack (target);
					if (target.stats.STATUS == "PSN") {
						Debug.Log(target.stats.NAME + " is poisoned");
					}
					if (target.stats.STATUS == "NA") {
						Debug.Log(target.stats.NAME + " did not get poisoned");
					}
				//}
			}
			
			stats.TIMER = stats.SPD;
		}	
		
		//Timer Bar
		timerbar.SetSize((stats.TIMER/stats.SPD));
		
		//Damage and Death
		if (stats.HP <= 0 ) {
			this.isDead = true;
			Death();
		}	
		
		if(heroes[0].isDead == true && heroes[1].isDead == true && heroes[2].isDead == true)
		{
			SceneManager.LoadScene("LoseBattle");
		}
		if ( enemy.isDead == true)
		{
			Victory();
		}
	}
	
	public void onAttackHero () {
		
		if ( enemy.isDead == false ) {
			enemy.stats.HP -= this.stats.PWR;
			//Debug.Log("hero " + stats.NAME + " attacked the " + enemy.stats.NAME );
			//this.stats.PWR -= bonusPWR;
			takeDamage(enemy);
			
		}
		
		else {
			Victory();
		}
		
	}
	
	public Battle_npc onAttackEnemy () {
		int roll = 0;
		while (true) {
			roll = Random.Range(0, 3); //<--checks which hero to target.
			if ( heroes[roll].isDead == false ) {
				heroes[roll].stats.HP -= this.stats.PWR;
				//Debug.Log(stats.NAME + " attacked the " + heroes[roll].stats.NAME );
				takeDamage(heroes[roll]);
				break;
			}
		}
		
		return heroes[roll];
		
	}
	
	public void Victory () {
		if ( enemy.isDead == true && enemy.stats.HP <= 0 ) {
			Debug.Log("YOU WIN!");
			SceneManager.LoadScene("WinBattle");
		}
	}
	
	public void takeDamage (Battle_npc target) { //<--put the target in the ()
		
			TMP_Text damageCounter = Instantiate(damagePrefab);
			damageCounter.transform.SetParent(canvas);
			damageCounter.text = this.stats.PWR.ToString();
			Vector3 newPos = Camera.main.WorldToScreenPoint(target.transform.position);
			damageCounter.transform.position = newPos;
	}
	
	public void takePoisonDamage (Battle_npc target) { //<--put the target in the ()
		
			TMP_Text poisonCounter = Instantiate(poisonPrefab);
			poisonCounter.color = new Color(0,0.75f,0,1);
			poisonCounter.transform.SetParent(canvas);
			poisonCounter.text = ailments.poisonDamage.ToString();
			Vector3 newPos = Camera.main.WorldToScreenPoint(target.transform.position);
			poisonCounter.transform.position = newPos;
	}	
	
	public void Death () {
		
        Destroy(this.gameObject);
		Debug.Log ( stats.NAME + " is dead");
		
	}

	
}
