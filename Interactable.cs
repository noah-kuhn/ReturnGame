using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
	public CharacterController player;
	private bool interactedWith;
	private bool triggered;
	public GameObject interactableObject;
    public Image dBox;
    public Text dText;
    public string[] textLines = new String[3];
    private int currentLine = -1;
	
    // Start is called before the first frame update
    public void Start()
    {
		interactedWith = false;
		triggered = false;
    }
	
	public void OnTriggerEnter2D(Collider2D c){
		triggered = true;
    }
	
	public void OnTriggerExit2D(Collider2D c){
		triggered = false;
        currentLine = -1;

    }

    // Update is called once per frame
    public void Update()
    {
        ActivateDialogue();
    }

    public void ActivateDialogue()
    {
        if (triggered && Input.GetKeyDown(KeyCode.Space))
        {
            dBox.gameObject.SetActive(true);
            dText.gameObject.SetActive(true);
            currentLine++;
			if(!isCombatScene){
				if (currentLine < textLines.Length)
				{
					dText.text = textLines[currentLine];
				}
				else
				{
					dBox.gameObject.SetActive(false);
					dText.gameObject.SetActive(false);
				}
			}else{
				if(currentLine < textLines.Length - 1){
					dText.text = textLines[currentLine];
				}else if(currentLine == textLines.Length - 1 && ((Monster) this).fightOver()){
					dText.text = textLines[currentLine];
				}else{
					dBox.gameObject.SetActive(false);
					dText.gameObject.SetActive(false);
				}
			}
        }
    }
	
	public bool isCombatScene(){
		return this is Monster;
	}
	
	//Set interactedWith to true
	public void interact(bool b){
		interactedWith = b;
	}
	
	//return true if has been interacted with
	public bool hasBeenInteractedWith(){
		return interactedWith;
	}
	
	//return triggered
	public bool isTriggered(){
		return triggered;
	}
	
}
