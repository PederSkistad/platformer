using UnityEngine;
using System.Collections;

public class Enemy_Movement_Arc : MonoBehaviour {

	public float speed;
	public int range;
	public float fallSpeed;
	public float jumpPower;

	private Rigidbody2D rb;
	private bool grounded;
	private Vector2 startPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		startPos = rb.position;
		grounded = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (grounded) {
			moveLeft ();
		} else if (! grounded) {
			quasiGravity();
		}
	}

	void OnCollisionEnter2D(Collision2D obj){
		//Sett grounded til true når objektet treffer noe med tag "Floor"
		if (obj.gameObject.tag == "Floor") {
			grounded = true;
		}
	}

	void quasiGravity() {
		float vx = rb.velocity.x;
		rb.AddForce (new Vector3 (vx, -fallSpeed, 0) * Time.deltaTime);
	}

	void moveArc ()  {
		rb.velocity.Normalize ();
		rb.AddForce (new Vector3 (speed*150, jumpPower*100, 0) * Time.deltaTime);
		grounded = false;

	}
	void moveLeft() {

		transform.Translate (new Vector3(-0.1f, 0, 0) * speed * Time.deltaTime);
		
		if (rb.position.x <= startPos.x - range) {
			moveArc();
		}

	}
}
