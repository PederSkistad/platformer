using UnityEngine;
using System.Collections;

public class Enemy_Movement_Bounce_Arc : MonoBehaviour {

	public float fallSpeed;
	public float speed;
	public float jumpPower;
	public string direction = "right";

	private Rigidbody2D rb;
	private bool grounded = true;

	void quasiGravity() {
		float vx = rb.velocity.x;
		rb.AddForce (new Vector3 (vx, -fallSpeed, 0) * Time.deltaTime);
	}
	
	void moveArc ()  {
		rb.velocity.Normalize ();
		if (direction == "left") {
			rb.AddForce (new Vector3 (-speed * 150, jumpPower * 100, 0) * Time.deltaTime);
		} else if (direction == "right") {
			rb.AddForce (new Vector3 (speed * 150, jumpPower * 100, 0) * Time.deltaTime);
		}
		grounded = false;
		
	}

	void OnCollisionEnter2D(Collision2D obj){
		//Sett grounded til true når objektet treffer noe med tag "Floor"
		if (obj.gameObject.tag == "Floor") {
			grounded = true;

			if (direction == "left") {
				direction = "right";
			} else {
				direction = "left";
			}
		}
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (grounded) {
			moveArc ();
		} else {
			quasiGravity();
		}
	}
}
