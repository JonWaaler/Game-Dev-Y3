using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
	// public isGrounded;

	// void OnCollisioneExit(Collision other)
	// {
	// 	if (other.gameObject.tag == "Floor")
	// 	{
	// 		isGrounded = false;
	// 		Debug.Log("false");
	// 	}
	// }


	void OnCollisionExit(Collision other)
	{
		if(other.transform.tag == "Player"){
			other.gameObject.GetComponent<Player>().isGrounded = false;
		}
	}
}
