using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Stick2Platform : MonoBehaviour {

	public Text test1;
	public Text test2;

	private Vector3 curLoc;
	private Vector3 lastLoc;
	private Rigidbody2D rb2d;
	private List<GameObject> onPlatform = new List<GameObject>();

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		lastLoc = new Vector3(rb2d.position.x, rb2d.position.y, 0f);
		curLoc = lastLoc;
	}

	void OnCollisionEnter2D(Collision2D other) {
		onPlatform.Add (other.gameObject);
	}

	void OnCollisionExit2D(Collision2D other) {
		onPlatform.Remove (other.gameObject);
	}

	void movePassenger () {
		if (onPlatform.Count > 0) {
			GameObject goOther = onPlatform[0].gameObject;
			Rigidbody2D rbOther = goOther.GetComponent<Rigidbody2D>();

			Vector3 passengerPos = new Vector3(rbOther.position.x, rbOther.position.y, 0f);
			float xDelta = passengerPos.x + (curLoc.x - lastLoc.x);
			test1.text = "xDelta: " + xDelta.ToString () + " lastLoc.x: " + lastLoc.x.ToString() + " curLoc.x: " + curLoc.x.ToString ();

			float yDelta = passengerPos.y + (curLoc.y - lastLoc.y);
			test2.text = "yDelta: " + yDelta.ToString () + " lastLoc.y: " + lastLoc.y.ToString() + " curLoc.y: " + curLoc.y.ToString ();

			goOther.GetComponent<Transform>().position = new Vector3 (xDelta, yDelta, 0f); 

		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		curLoc = new Vector3(rb2d.position.x, rb2d.position.y, 0f);
		movePassenger ();
		lastLoc = curLoc;
	}
}
