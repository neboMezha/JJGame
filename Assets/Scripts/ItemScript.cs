using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {
	
	private Vector3 spawnPos;		//spawn position of the item
	private Vector3 topPt;			//highest point the item reaches
	private Vector3 vel;			//item's velocity

	private bool falling;			//tracks if the item is falling or not
	public bool hit;
	public bool paused;

	private float mult;				//speed multiplier
	private float speed;			//speed

	// Use this for initialization
	void Start () {
		paused = false;
		falling = false;
		hit = false;
		mult = 1.0f;
		speed = -0.2f * mult;

		spawnPos = new Vector3 (11f, 0.0f, 0);
		topPt = new Vector3( 0, 3.4f, 0);

	}
	
	// Update is called once per frame
	void Update () {
		//-----Only Runs while NOT paused
		if (!paused) {
			//-----General Falling
			if (!hit) {
				if (!falling) {								//set a positive velocity if item isn't falling yet
					vel = topPt - this.transform.position;
				}

				if (vel.y <= 0.1f) {						//once velocity reaches almost 0, set to falling and set a negative velocity
					falling = true;
					vel = this.transform.position - topPt;
				}

				this.transform.position += new Vector3 (speed, vel.y / 10 * mult, 0);	// moves the item
			} 
		//------When HIT by player
		else {
				if (this.transform.position.x <= 10f) { //if NOT off screen
					this.transform.position += new Vector3 (0.5f, 0, 0);	// moves the item
				} else {		//set hit to false if it's off screen
					hit = false;
					Respawn ();
				}
			}
		}
	}

	public void Respawn(){ //respawns the item
		
		vel = Vector3.zero;
		falling = false;
		this.transform.position = spawnPos;
	}
}
