using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleToRun : MonoBehaviour {

    Animator animator;
    public float InputX;
    public float InputY;
    private float PNum;

	// Use this for initialization
	void Start () {
        animator = this.gameObject.GetComponent<Animator>();

        if (transform.parent.gameObject.name == "Player1_Parent 1")
            PNum = 1;
        else if (transform.parent.gameObject.name == "Player2_Parent 2")
            PNum = 2;
        else if (transform.parent.gameObject.name == "Player3_Parent 3")
            PNum = 3;
        else if (transform.parent.gameObject.name == "Player4_Parent 4")
            PNum = 4;
    }
	
	// Update is called once per frame
	void Update () {
        InputY = Input.GetAxis("V_LStick" + PNum);
        InputX = Input.GetAxis("H_LStick" + PNum);
        animator.SetFloat("InputX", InputY);
        animator.SetFloat("InputZ", InputX);
        if (Input.GetButtonDown("RB" + PNum))
        {
            //switch animation
            animator.SetBool("IsGrapple", true);
        }
        else
            animator.SetBool("IsGrapple", false);
    }
}
