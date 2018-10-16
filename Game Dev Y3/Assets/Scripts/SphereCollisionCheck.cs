using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollisionCheck : MonoBehaviour {

    public bool isCollision = false;
    public bool isPlayerCollision = false;
    public GameObject playerThrow;
    public GameObject playerHit;
    public GameObject DebugVaraiable;


    private void OnTriggerEnter(Collider other)
    {
        DebugVaraiable = other.gameObject;

        // only check for wall collisions
        if (other.transform.tag == "Wall")
            isCollision = true;
        else
            isCollision = false;

        if (other.transform.tag == "Player" && other.gameObject != playerThrow)
        {
            isPlayerCollision = true;
            playerHit = other.gameObject;
        }
        else
        {
            isPlayerCollision = false;
        }

   //     print(other.gameObject.tag);
//        print("colliding with: " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        DebugVaraiable = null;

        if (other.transform.tag == "Wall")
            isCollision = false;

        if (other.transform.tag == "Player")
        {
            isPlayerCollision = false;
            playerHit = null;
        }

  //      print(other.gameObject.name + " no longer colliding");
    }
}
