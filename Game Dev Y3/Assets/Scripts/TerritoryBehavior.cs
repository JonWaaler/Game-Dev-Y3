using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player Container")
        {
            if (collision.transform.GetChild(1).tag == "Gun")
            {
                collision.transform.GetChild(1).GetComponent<GunBehavior>().Damage = 100;
            }
            else
                print("<color = red>ERROR: Set " + collision.gameObject.name + "'s TAG to Gun./n Or");
        }
    }
}
