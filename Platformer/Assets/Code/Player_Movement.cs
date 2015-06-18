using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public float speed;
	public float jumpPower;

	private Rigidbody2D rb;
	private bool grounded;
	private bool hasJumped;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		grounded = true;
		hasJumped = false;
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
		Movement ();
		slowDown ();


	}

	void slowDown() {
		if (rb.velocity != Vector2.zero && grounded) {
			if (! Input.anyKey) {
				rb.velocity *= (0.8f);
			}
		}
	}

	void Movement() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		
		rb.AddForce (movement * speed);
	}
}
