using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float rotationsPerMinute;
	void Update()
	{
		transform.Rotate(0,0,10*rotationsPerMinute*Time.deltaTime);
	}
}
