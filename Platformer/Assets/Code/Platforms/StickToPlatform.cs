using UnityEngine;
using System.Collections;

public class StickToPlatform : MonoBehaviour {

	// helper struct to contain the transform of the player and the
	// vertical offset of the player (how high the center of the
	// charcontroller must be above the center of the platform)
	public struct Data {
		public Data(Rigidbody2D rb2d, Transform t, float yOffset) {
			this.rb2d = rb2d;
			this.t = t;
			this.yOffset = yOffset;
		}
		public Rigidbody2D rb2d; // the char controller
		public Transform t; // transform of char
		public float yOffset; // y offset of char above platform center
	};
	
	public float verticalOffset = 0.5f; // height above the center of object the char must be kept
	
	// store all playercontrollers currently on platform
	private Hashtable onPlatform = new Hashtable();
	
	// used to calculate horizontal movement
	private Vector3 lastPos;
	
	void OnCollisionEnter2D(Collision2D other) {
		Rigidbody2D rb2d = other.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		
		// make sure we only move objects that are rigidbodies or charactercontrollers.
		// this to prevent we move elements of the level itself
		if (rb2d == null) return;
		
		Transform t = other.transform; // transform of character

		// we calculate the yOffset from the character height and center
		float yOffset = other.gameObject.GetComponent<Collider2D>().bounds.extents.y / 2f - rb2d.centerOfMass.y + verticalOffset;
	
		Data data = new Data(rb2d, t, yOffset);
		
		// add it to table of characters on this platform
		// we use the transform as key
		onPlatform.Add(other.transform, data);
	}
	
	void OnCollisionExit2D(Collision2D other) {
		// remove (if in table) the uncollided transform
		onPlatform.Remove(other.transform);
	}
	
	void Start() {
		lastPos = transform.position;
	}
	
	void FixedUpdate () {
		Vector3 curPos = transform.position;
		float y = curPos.y; // current y pos of platform
		
		// we calculate the delta
		Vector3 delta = curPos - lastPos;
		float yVelocity = delta.y;
		
		// remove y component of delta (as we use delta only for correcting
		// horizontal movement now...
		delta.y = 0f;
		
		lastPos = curPos;
		
		// let's loop over all characters in the table
		foreach (DictionaryEntry d in onPlatform) {
			Data data = (Data) d.Value; // get the data
			float charYVelocity = data.rb2d.velocity.y;
			
			// check if char seems to be jumping
			if ((charYVelocity <= 0f) || (charYVelocity <= yVelocity)) {
				// no, lets do our trick!
				Vector3 pos = data.t.position; // current charactercontroller position
				pos.y = y + data.yOffset; // adjust to new platform height
				pos += delta; // adjust to horizontal movement
				data.t.position = pos; // and write it back!
			}
		}
	}
}
