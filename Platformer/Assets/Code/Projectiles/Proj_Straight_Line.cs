using UnityEngine;
using System.Collections;

public class Proj_Straight_Line : MonoBehaviour {

	public GameObject projectile;
	public float fireRate = 2F;
	public float projSpeed = 0.5f;

	private GameObject clone;
	private float nextFire = 0.0F;

	void Start() {
	}

	void FixedUpdate() {

		if (Time.time > nextFire) {
			GameObject playR = GameObject.FindGameObjectWithTag("Player");
			nextFire = Time.time + fireRate;

			clone = (GameObject)(Instantiate(projectile, projectile.transform.position, transform.rotation));
			Vector3 gogo = new Vector3(playR.GetComponent<Rigidbody2D>().position.x, playR.GetComponent<Rigidbody2D>().position.y, 0f);
			clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(gogo);
		}

	}
}

