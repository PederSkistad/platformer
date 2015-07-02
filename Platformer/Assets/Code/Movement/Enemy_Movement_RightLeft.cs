using UnityEngine;
using System.Collections;

public class Enemy_Movement_RightLeft : MonoBehaviour {

	public float speed;
	public int range;
	
	private Rigidbody2D rb;
	private string direction = "Right";
	private Vector2 startPos;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		startPos = rb.position;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}
	
	void Movement() {
		
		if (direction == "Right") {
			transform.Translate(new Vector3(0.1f, 0, 0) * speed * Time.deltaTime);
			
			if (rb.position.x >= startPos.x + range) {
				direction = "Left";
			}
			
		} else if (direction == "Left") {
			transform.Translate (new Vector3(-0.1f, 0, 0) * speed * Time.deltaTime);
			
			if (rb.position.x <= startPos.x - range) {
				direction = "Right";
			}
			
		}
		
	}
}
