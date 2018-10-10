using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float xVel;
	private float zvel;
	private float xFire;
	private float yFire;
	private Vector3 inputVector;

	public float speed;
	public string H_LS_PNum, V_LS_PNum, H_RS_PNum, V_RS_PNum, AButton_PNum;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	[Range(1, 10)]
	public float jumpVelocity;


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update ()
	{
		xVel = Input.GetAxis(H_LS_PNum);
		zvel = Input.GetAxis(V_LS_PNum);

		inputVector = new Vector3(xVel, 0, zvel);

		//print("X_Vel: "+ xVel);
		//print("z_Vel: "+ zvel);

		if (xVel != 0 || zvel != 0)
		{
			GetComponent<Rigidbody>().AddForce(inputVector.normalized * speed);
		}

		GetComponent<Rigidbody>().velocity = new Vector3 (speed * xVel, GetComponent<Rigidbody>().velocity.y, speed * zvel);

		Vector3 playerDirection = Vector3.right * Input.GetAxisRaw(H_RS_PNum) + Vector3.forward * -Input.GetAxisRaw(V_RS_PNum);
		if(playerDirection.sqrMagnitude > 0.0f)
		{
            //playerDirection.z += 45;
			transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up) ;
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        }

		if (Input.GetButtonDown(AButton_PNum) && GetComponent<Rigidbody>().velocity.y == 0)
		{
			GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
		}
		if (GetComponent<Rigidbody>().velocity.y < 0)
		{
			GetComponent<Rigidbody>().velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (GetComponent<Rigidbody>().velocity.y > 0 && !Input.GetButton(AButton_PNum))
		{
			GetComponent<Rigidbody>().velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

	}	
	void FixedUpdate()
	{
		
	}
}
