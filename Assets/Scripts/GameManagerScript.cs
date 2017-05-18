using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	private bool paused;

	public GameObject itemPrefab;

	private GameObject item;
	public List <GameObject> items;
	private Vector3 spawnPos;
	private float dist;

	// Use this for initialization
	void Start () {
		dist = 0;
		paused = false;
		spawnPos = new Vector3 (11f, 0.6f, 0);

		//for (int i = 0; i < 4; i++) {
			item = Instantiate (itemPrefab, spawnPos, Quaternion.identity);
			items.Add (item);
		//}

		dist = Vector3.Distance (item.transform.position, this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			Pause ();
		}
	}

	public void Tap(){
		dist = item.transform.position.x - this.transform.position.x;


		Debug.Log (dist);


		if (dist <= 3f) {
			item.GetComponent<ItemScript> ().hit = true;
			//item.GetComponent<ItemScript>().Respawn ();
		}

	}

	void OnTriggerEnter2D(Collider2D playerCol){
		Debug.Log ("TRIGGERED");

		Pause ();
		item.GetComponent<ItemScript>().Respawn ();
	}

	private void Pause(){
		paused = !paused;
		if (paused) {
			item.GetComponent<ItemScript> ().paused = true;
		} else {
			item.GetComponent<ItemScript> ().paused = false;
		}
	}
}
