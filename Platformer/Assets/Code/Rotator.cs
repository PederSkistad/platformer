using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public float rotationsPerMinute;
	void Update()
	{
		transform.Rotate(0,6.0*rotationsPerMinute*Time.deltaTime,0);
}
