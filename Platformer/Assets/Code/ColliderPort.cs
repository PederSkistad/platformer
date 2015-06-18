using UnityEngine;
using System.Collections;

public class ColliderPort : MonoBehaviour {


	public Transform b;
	public Vector3 c;


	void OnTriggerEnter2D(Collider2D other) {
		b.position = c;

	}
}

