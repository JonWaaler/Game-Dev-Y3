using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float xVel;
	private float yVel;
	private float xFire;
	private float yFire;
	private Vector3 inputVector;

	public float speed;
	public string H_LS_PNum, V_LS_PNum, H_RS_PNum, V_RS_PNum;


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update ()
	{
		xVel = Input.GetAxis(H_LS_PNum);
		yVel = Input.GetAxis(V_LS_PNum);

		inputVector = new Vector3(xVel, 0, yVel);

		//print("X_Vel: "+ xVel);
		//print("z_Vel: "+ yVel);

		if (xVel != 0 || yVel != 0)
		{
			GetComponent<Rigidbody>().AddForce(inputVector.normalized * speed);
		}

		GetComponent<Rigidbody>().velocity = new Vector3 (speed * xVel, -9.8f, speed * yVel);

		Vector3 playerDirection = Vector3.right * Input.GetAxisRaw(H_RS_PNum) + Vector3.forward * -Input.GetAxisRaw(V_RS_PNum);
		if(playerDirection.sqrMagnitude > 0.0f)
		{
            //playerDirection.z += 45;
			transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up) ;
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        }


	}
}
