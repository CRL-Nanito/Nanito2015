﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision){

		if (collision.gameObject.tag == "Enemy") {
			Destroy(this.gameObject);
			Destroy(collision.gameObject);
			
		}

		if (collision.gameObject.tag == "platform") {
			Destroy(this.gameObject);

		}

		if (collision.gameObject.tag == "lever") {
			Destroy(this.gameObject);
			
		}

		if (collision.gameObject.tag == "lever1") {
			Destroy(this.gameObject);
			
		}

		if (collision.gameObject.tag == "lever") {
			if (LeverScript.hitcount == 2) {
				RobotArm.move = true;
			} else LeverScript.hitcount += 1;
		}
		
		if (collision.gameObject.tag == "lever") {
			if (LeverScript.hitcount1 == 2) {
				RobotArm.move1 = true;
			} else LeverScript.hitcount1 += 1;

		}


	}

}
