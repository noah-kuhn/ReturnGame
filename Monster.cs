using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Interactable
{
	
	[SerializeField] int health;
	[SerializeField] int damage;
	[SerializeField] int armor;
	private bool completedCombat = false;
	
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
		if(isTriggered()){
			if(player.getDamage() > armor){
				int damageTaken = calculateDamage();
				textLines[1] = "If you attack this monster, you will take " + damageTaken + " damage. Press [SPACE] to attack!";
				textLines[2] = "Health remaining: " + (player.getHealth() - damageTaken);
				ActivateDialogue(true);
				if(Input.GetKey(KeyCode.Space)){
					Destroy(interactableObject);
					player.changeHealth(-1 * damageTaken);
					completedCombat = true;
				}
			}
		}
    }
	
	public bool fightOver(){
		return completedCombat;
	}
	
	public int calculateDamage(){
		int damageTaken = (health/(player.getDamage() - armor) -  1) * (damage - player.getArmor());
		return damageTaken;
	}
	
}
