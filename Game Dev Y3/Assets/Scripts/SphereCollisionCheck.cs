using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollisionCheck : MonoBehaviour {

    public bool isCollision = false;

    private void OnTriggerEnter(Collider other)
    {
        // only check for wall collisions
        if (other.transform.tag == "Wall")
            isCollision = true;
        else
            isCollision = false;

        print(other.gameObject.tag);
        print("colliding with: " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Wall")
            isCollision = false;
        print(other.gameObject.name + " no longer colliding");
    }
}
