using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(20,80);
	public Vector2 size = new Vector2(90,120);
	public Texture2D emptyTex;
	public Texture2D fullTex;
	public Slider slider;
	bool refuel;
	void Start(){
		slider.value = 100;
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "spotlight"){
			refuel = true;
		}
	}
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "spotlight"){
			refuel = false;
		}
	}
	
	void Update() {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
			slider.value = slider.value - 0.002f ;
		}
		else if(refuel){
			slider.value = slider.value + 0.007f;
		}
	}
}
