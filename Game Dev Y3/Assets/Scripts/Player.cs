using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float xVel;
	private float zvel;
	private Vector3 inputVector;
	public bool isGrounded;

	public float speed;
	public string H_LS_PNum, V_LS_PNum, H_RS_PNum, V_RS_PNum, AButton_PNum;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	[Range(1, 10)]
	public float jumpVelocity;

	public Rigidbody rb;

	void Awake ()
	{
		Rigidbody rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
	{
		xVel = Input.GetAxis(H_LS_PNum);
		zvel = Input.GetAxis(V_LS_PNum);

		inputVector = new Vector3(xVel, 0, zvel);

		if (xVel != 0 || zvel != 0)
		{
			rb.AddForce(inputVector.normalized * speed);
		}

		rb.velocity = new Vector3 (speed * xVel, rb.velocity.y, speed * zvel);

		Vector3 playerDirection = Vector3.right * Input.GetAxisRaw(H_RS_PNum) + Vector3.forward * -Input.GetAxisRaw(V_RS_PNum);
		if(playerDirection.sqrMagnitude > 0.0f)
		{
            //playerDirection.z += 45;
			transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up) ;
            //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        }

		if (Input.GetButtonDown(AButton_PNum) && isGrounded)
		{
			rb.velocity = new Vector3(0, jumpVelocity, 0);
		}

		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (rb.velocity.y > 0 && !Input.GetButton(AButton_PNum))
		{
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

	}

	
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "MovableObj")
		{
			transform.SetParent(other.transform);
        }
		else
		{
			transform.SetParent(null);
		}
    }

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "MovableObj")
		{
			isGrounded = true;
		}
	}

	// void OnCollisioneExit(Collision other)
	// {
	// 	if (other.gameObject.tag == "Floor")
	// 	{
	// 		isGrounded = false;
	// 		Debug.Log("false");
	// 	}
	// }
}
