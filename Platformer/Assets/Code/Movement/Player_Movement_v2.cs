using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Movement_v2 : MonoBehaviour
{

	public float speed;
	public float jumpPower;
	public float fallSpeed;
	//public Text testing;

	private Rigidbody2D rb;
	private bool grounded;
	private bool hasJumped;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		grounded = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		quasiGravitation ();

		if (grounded) {
			Jump ();
		}

		Movement ();
		//testing.text = grounded.ToString ();
	}

	void OnCollisionEnter2D(Collision2D obj){
		//Sett grounded til true når objektet treffer noe med tag "Floor"
		if (obj.gameObject.tag == "Floor") {
			grounded = true;
		}
	}

	void quasiGravitation() {
		float vx = rb.velocity.x;
		rb.AddForce (new Vector3 (vx, -fallSpeed, 0) * Time.deltaTime);
	}

	void Jump() {
		if (Input.GetButtonDown ("Jump")) {
			float vx = rb.velocity.x;
			//float vy = rb.position.y;
			rb.AddForce (new Vector3 (vx, jumpPower*100, 0) * Time.deltaTime);
			grounded = false;
		}	
	}

	void Movement() {
		float moveHoriz = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHoriz, rb.velocity.y, 0);

		transform.Translate (movement * speed * Time.deltaTime);

	}
}

