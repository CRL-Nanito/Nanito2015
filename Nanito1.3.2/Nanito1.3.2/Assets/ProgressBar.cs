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
	bool circulo = false;
	bool triangulo = false;

	public Image fadeimage;
	public float fadespeed = 30f;
	public Color fadecolor = new Color (0f, 0f, 0f, 1f); 

	void Start(){
		slider.value = 100;
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "spotlight"){
			refuel = true;
		}
		else if(other.gameObject.tag == "teleport 1"){
			triangulo = false;
			circulo = true;
			//fadeimage.color = fadecolor;
			transform.position = new Vector3 (-264f, -65f, 574.2f);
			transform.rotation = Quaternion.Euler(359.69f, 179.9999f, 0);
			this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			//fadeimage.color = Color.Lerp (fadeimage.color, Color.clear, fadespeed * Time.deltaTime);
			//fadeimage.color = Color.clear;
			Debug.Log("fade back");


		}
		else if(other.gameObject.tag == "teleport 2"){
			triangulo = true;
			circulo = false;
			//fadeimage.color = fadecolor;
			transform.position = new Vector3 (-770.4f, -60f, 177.1f);
			transform.rotation = Quaternion.Euler(359.69f, 181.4886f, 0);
			this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;		
			//fadeimage.color = Color.Lerp (fadeimage.color, Color.clear, fadespeed * Time.deltaTime);
			//fadeimage.color = Color.clear;
			Debug.Log("fade back");

		}

	}
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "spotlight"){
			refuel = false;
		}
		else if(other.gameObject.tag == "teleport 1"){
			fadeimage.color = Color.Lerp (fadeimage.color, Color.clear, fadespeed * Time.deltaTime);

		}
		else if(other.gameObject.tag == "teleport 2"){
		
			fadeimage.color = Color.Lerp (fadeimage.color, Color.clear, fadespeed * Time.deltaTime);
			
			
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

		if (slider.value <= 0) {
			if (circulo) {
				//GetComponent<Renderer> ().enabled = false;
				transform.position = new Vector3 (-264f, -65f, 574.2f);
				transform.rotation = Quaternion.Euler(359.69f, 179.9999f, 0);
				this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				//GetComponent<Renderer> ().enabled = true;
			} else if (triangulo) {
			
				transform.position = new Vector3 (-770.4f, -60f, 177.1f);
				transform.rotation = Quaternion.Euler(359.69f, 181.4886f, 0);
				this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

			} else 
				Application.LoadLevel ("Car");
		}
	}
}
